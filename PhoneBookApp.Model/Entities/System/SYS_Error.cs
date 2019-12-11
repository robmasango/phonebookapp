using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Model.Entities.System
{
    public class SYS_Error : IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
