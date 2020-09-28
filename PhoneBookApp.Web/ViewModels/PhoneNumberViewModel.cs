using PhoneBookApp.Model.Entities.PhoneBook;
using System.Collections.Generic;

namespace PhoneBookApp.Web.Models
{
  public class PhoneNumberViewModel
  {
    public int Id { get; set; }
    public int PhoneBookId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Number { get; set; }

    public PhoneNumberViewModel()
    {

    }

    public PhoneNumberViewModel(PHB_PhoneNumber d)
    {
      MapSinglePhoneNumber(d);
    }

    public PhoneNumberViewModel MapSinglePhoneNumber(PHB_PhoneNumber d)
    {
      Id = d.Id;
      PhoneBookId = d.PhoneBookId;
      Name = d.Name;
      Email = d.Email;
      Number = d.Number;
      return this;
    }

    public PHB_PhoneNumber ReverseMap()
    {
      return new PHB_PhoneNumber()
        {
        Id = this.Id,
        PhoneBookId = this.PhoneBookId,
        Name = this.Name,
        Email = this.Email,
        Number = this.Number,
      };
    }

    public static List<PhoneNumberViewModel> MultiplePhoneNumberMap(List<PHB_PhoneNumber> divisions)
    {
      List<PhoneNumberViewModel> divisionVM = new List<PhoneNumberViewModel>();
      foreach (var d in divisions)
      {
        PhoneNumberViewModel sVm = new PhoneNumberViewModel(d);
        divisionVM.Add(sVm);
      }
      return divisionVM;
    }
  }
}
