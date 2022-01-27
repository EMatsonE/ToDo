using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ToDo.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool IsComplete { get; set; }


        public User User { get; set; }
    }
}
