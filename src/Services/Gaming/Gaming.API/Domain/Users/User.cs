using System;

namespace Gaming.API.Domain.Users
{
    public class User
    {
        public string Id { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }
    }
}
