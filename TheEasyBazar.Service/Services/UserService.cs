using AutoMapper;
using TheEasyBazar.Data.IRepositories;
using TheEasyBazar.Domain.Entities;
using TheEasyBazar.Service.DTOs.Users;
using TheEasyBazar.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using TheEasyBazar.Service.Exceptions;

namespace TheEasyBazar.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> userRepository;

    public UserService(IMapper mapper, IRepository<User> userRepository)
    {
        this._mapper = mapper;
        this.userRepository = userRepository;
    }
    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var user = await this.userRepository.SelectAll().
            FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower());

        if (user is not null)
            throw new CustomException(409, "User is alrady exists");

        var mappedUser = this._mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;
        
        var result = await this.userRepository.InsertAsync(mappedUser);
        
        return this._mapper.Map<UserForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.userRepository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found");

        await this.userRepository.DeleteAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetriveAllAsync()
    {
        var users = await this.userRepository.SelectAll().
            ToListAsync();

        return this._mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto?> RetriveByIdAsync(long id)
    {
        var user = await this.userRepository.SelectByIdAsync(id);

        if (user is null)
            throw new CustomException(404, "User is not found");

        return this._mapper.Map<UserForResultDto>(user);
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var user = await this.userRepository.SelectByIdAsync(dto.Id);

        if (user is null)
            throw new CustomException(404, "User is not found");

        var mappedUser = this._mapper.Map(dto, user);
        mappedUser.UpdatedAt = DateTime.UtcNow;
        var result = await this.userRepository.UpdateAsync(mappedUser);

        return this._mapper.Map<UserForResultDto>(result);
    }
}
