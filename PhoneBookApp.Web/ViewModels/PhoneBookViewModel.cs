using PhoneBookApp.Model.Entities.PhoneBook;
using System.Collections.Generic;

namespace PhoneBookApp.Web.Models
{
  public class PhoneBookViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public PhoneBookViewModel()
    {
    }

    public PhoneBookViewModel(PHB_PhoneBook i)
    {
      MapSinglePhoneBook(i);
    }

    public PhoneBookViewModel MapSinglePhoneBook(PHB_PhoneBook phoneb)
    {
      Id = phoneb.Id;
      Name = phoneb.Name;
      return this;
    }

    public PHB_PhoneBook ReverseMap()
    {
      return new PHB_PhoneBook()
      {
        Id = this.Id,
        Name = this.Name,
      };
    }

    public static List<PhoneBookViewModel> MultiplePhoneBooksMap(List<PHB_PhoneBook> addressTypes)
    {
      List<PhoneBookViewModel> addressTypeVM = new List<PhoneBookViewModel>();
      foreach (var s in addressTypes)
      {
        PhoneBookViewModel sVm = new PhoneBookViewModel(s);
        addressTypeVM.Add(sVm);
      }
      return addressTypeVM;
    }
  }
}