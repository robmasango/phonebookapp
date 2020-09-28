using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Model.Entities.PhoneBook
{
  public class PHB_PhoneBook : IEntityBase
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual ICollection<PHB_PhoneNumber> PhoneNumbers { get; set; }
  }
}
