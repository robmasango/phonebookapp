using System.ComponentModel.DataAnnotations;
namespace PhoneBookApp.Model.Entities.PhoneBook
{
  public class PHB_PhoneNumber : IEntityBase
  {

    [Key]
    public int id { get; set; }
    public int phonebookid { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string number { get; set; }
    public virtual PHB_PhoneBook PhoneBook { get; set; }
  }
}
