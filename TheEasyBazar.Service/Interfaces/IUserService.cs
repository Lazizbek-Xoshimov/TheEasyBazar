using TheEasyBazar.Service.DTOs.Users;

namespace TheEasyBazar.Service.Interfaces;

public interface IUserService
{
    public Task<bool> RemoveAsync(long id);
    public Task<UserForResultDto?> RetriveByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> RetriveAllAsync();
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
}
