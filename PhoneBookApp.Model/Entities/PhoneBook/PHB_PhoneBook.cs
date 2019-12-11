using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Model.Entities.PhoneBook
{
  public class PHB_PhoneBook : IEntityBase
  {
    [Key]
    public int id { get; set; }
    [Required]
    public string name { get; set; }
    public virtual ICollection<PHB_PhoneNumber> PhoneNumbers { get; set; }
  }
}
