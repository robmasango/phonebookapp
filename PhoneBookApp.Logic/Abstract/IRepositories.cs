using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model.Entities.System;
using System.Collections.Generic;

namespace PhoneBookApp.Logic.Abstract
{
  //PhoneBook
  public interface IPhoneBookRepository : IEntityBaseRepository<PHB_PhoneBook>
  {
    List<PHB_PhoneBook> GetAllPhoneBooks();
    PHB_PhoneBook GetPhoneBookByID(int PhoneBookID);
    int CountPhoneBooks();
    void AddPhoneBook(PHB_PhoneBook PHB_PhoneBook);
    List<PHB_PhoneBook> GetPhoneBooksOrdered(string filter = null);
    PHB_PhoneBook GetFirstPhoneBook();
  }

  public interface IPhoneNumberRepository : IEntityBaseRepository<PHB_PhoneNumber>
  {
    List<PHB_PhoneNumber> GetAllPhoneNumbers();
    List<PHB_PhoneNumber> GetPhoneNumberByPhoneBookID(int PhoneBookID);
    PHB_PhoneNumber GetPhoneNumberByID(int ID);
    int CountPhoneNumbers();
    void AddPhoneNumber(PHB_PhoneNumber PHB_PhoneNumber);
    List<PHB_PhoneNumber> GetPhoneNumbersOrdered(string filter = null);
    void UpdatePhoneNumber(PHB_PhoneNumber PHB_PhoneNumber);
    void DeletePhoneNumber(int Id);
  }

  //System
  public interface ILoggingRepository : IEntityBaseRepository<SYS_Error> { }

}
