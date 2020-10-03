using Microsoft.AspNetCore.Identity;
using System;

namespace Gaming.API.Infrastructure.Data.Community.Models
{
    public class FiveUser : IdentityUser
    {
        public DateTime RegisteredAt { get; set; }
    }
}
