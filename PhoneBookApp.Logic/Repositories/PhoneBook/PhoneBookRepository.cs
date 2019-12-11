using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Logic.Repositories.PhoneBook
{
  public class PhoneBookRepository : EntityBaseRepository<PHB_PhoneBook>, IPhoneBookRepository
    {
        private readonly PhoneBookAppContext _context;

        public PhoneBookRepository(PhoneBookAppContext context)
        : base(context)
        {
            this._context = context;
        }

        public PHB_PhoneBook GetPhoneBookByID(int id)
        {
            return FindSingle(subject => subject.id == id);
        }

        public List<PHB_PhoneBook> GetAllPhoneBooks()
        {
            return LoadAll();
        }

        public PHB_PhoneBook GetFirstPhoneBook()
        {
          var PHB_PhoneBook = _context.Set<PHB_PhoneBook>()
          .FirstOrDefault();

          return PHB_PhoneBook;
        }

    public PHB_PhoneBook GetPhoneBook(string name)
        {
            return FindSingle(a => a.name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public int CountPhoneBooks()
        {
            return _context.Set<PHB_PhoneBook>().Count();
        }

        public void AddPhoneBook(PHB_PhoneBook PHB_PhoneBook)
        {
            Add(PHB_PhoneBook);
            Commit();
        }

        public void DeletePhoneBook(int Id)
        {
            DeleteWhere(c => c.id == Id);
            Commit();
        }

        public void UpdatePhoneBook(PHB_PhoneBook PHB_PhoneBook)
        {
            Update(PHB_PhoneBook);
            Commit();
        }
        

        public List<PHB_PhoneBook> GetPhoneBooksOrdered(string filter = null)
        {
            var record = _context.Set<PHB_PhoneBook>()
               .OrderBy(c => c.id)
                .ToList();

            return record;
        }                    
    }
}
