using System.ComponentModel.DataAnnotations;
namespace PhoneBookApp.Model.Entities.PhoneBook
{
  public class PHB_PhoneNumber : IEntityBase
  {

    [Key]
    public int Id { get; set; }
    public int PhonebookId { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Number { get; set; }
    public virtual PHB_PhoneBook PhoneBook { get; set; }
  }
}
