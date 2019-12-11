using PhoneBookApp.Model.Entities.PhoneBook;
using System.Collections.Generic;

namespace PhoneBookApp.Web.Models
{
  public class PhoneNumberViewModel
  {
    public int id { get; set; }
    public int phonebookid { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string number { get; set; }

    public PhoneNumberViewModel()
    {

    }

    public PhoneNumberViewModel(PHB_PhoneNumber d)
    {
      MapSinglePhoneNumber(d);
    }

    public PhoneNumberViewModel MapSinglePhoneNumber(PHB_PhoneNumber d)
    {
      id = d.id;
      phonebookid = d.phonebookid;
      name = d.name;
      email = d.email;
      number = d.number;
      return this;
    }

    public PHB_PhoneNumber ReverseMap()
    {
      return new PHB_PhoneNumber()
      {
        id = this.id,
        phonebookid = this.phonebookid,
        name = this.name,
        email = this.email,
        number = this.number,
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
