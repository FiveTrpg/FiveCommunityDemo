using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gaming.API.Infrastructure.Data.Community.Models
{
    public class PersistedChannel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public FiveUser Owner { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
