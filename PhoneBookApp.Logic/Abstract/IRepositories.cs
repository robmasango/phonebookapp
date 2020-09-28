using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model.Entities.System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBookApp.Logic.Abstract
{
  //PhoneBook
  public interface IPhoneBookRepository : IEntityBaseRepository<PHB_PhoneBook>
  {
        Task<List<PHB_PhoneBook>> GetAllPhoneBooks();
        Task<PHB_PhoneBook> GetPhoneBookByID(int PhoneBookID);
        Task<int> CountPhoneBooks();
        Task AddPhoneBook(PHB_PhoneBook PHB_PhoneBook);
        Task UpdatePhoneBook(PHB_PhoneBook PHB_PhoneBook);
        Task<List<PHB_PhoneBook>> GetPhoneBooksOrdered(string filter = null);
        Task<PHB_PhoneBook> GetFirstPhoneBook();
  }

  public interface IPhoneNumberRepository : IEntityBaseRepository<PHB_PhoneNumber>
  {
        Task<List<PHB_PhoneNumber>> GetAllPhoneNumbers();
        Task<List<PHB_PhoneNumber>> GetPhoneNumberByPhoneBookID(int PhoneBookID);
        Task<PHB_PhoneNumber> GetPhoneNumberByID(int ID);
        Task<int> CountPhoneNumbers();
        Task AddPhoneNumber(PHB_PhoneNumber PHB_PhoneNumber);
        Task<List<PHB_PhoneNumber>> GetPhoneNumbersOrdered(string filter = null);
        Task UpdatePhoneNumber(PHB_PhoneNumber PHB_PhoneNumber);
        Task DeletePhoneNumber(int Id);
  }

  //System
  public interface ILoggingRepository : IEntityBaseRepository<SYS_Error> { }

}
