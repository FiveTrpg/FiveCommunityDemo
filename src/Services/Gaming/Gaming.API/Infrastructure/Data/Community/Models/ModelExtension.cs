using Gaming.API.Domain.Users;

namespace Gaming.API.Infrastructure.Data.Community.Models
{
    public static class ModelExtension
    {
        public static User ToDomainUser(this FiveUser rawUser)
        {
            return new User()
            {
                Id = rawUser.Id,
                Email = rawUser.Email,
                NickName = rawUser.UserName,
                RegisteredAt = rawUser.RegisteredAt,
            };
        }
    }
}
