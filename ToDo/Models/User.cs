using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(30)]
        [Required]
        public string Email { get; set; }
        [StringLength(30)]
        [Required]
        public string Password { get; set; }


        public ICollection<Task> Task { get; set; }
    }
}
