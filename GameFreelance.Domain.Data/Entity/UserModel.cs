using System;
using System.ComponentModel.DataAnnotations;

namespace GameFreelance.Domain.Core.Entity
{
    public class UserModel
    {
        [Key] 
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VKontakteId { get; set; }
        public Guid Password { get; set; }
    }
}
