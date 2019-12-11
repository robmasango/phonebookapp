using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBookApp.Logic.Repositories.PhoneBook
{
  public class PhoneNumberRepository : EntityBaseRepository<PHB_PhoneNumber>, IPhoneNumberRepository
    {
        private readonly PhoneBookAppContext _context;

        public PhoneNumberRepository(PhoneBookAppContext context)
        : base(context)
        {
            this._context = context;
        }

        public PHB_PhoneNumber GetPhoneNumberByID(int id)
        {
            return FindSingle(subject => subject.id == id);
        }

        public List<PHB_PhoneNumber> GetPhoneNumberByPhoneBookID(int PhoneBookID)
        {
          var PHB_PhoneNumber = _context.Set<PHB_PhoneNumber>()
          .Where(x => x.phonebookid == PhoneBookID)
          .ToList();

          return PHB_PhoneNumber;
        }

        public List<PHB_PhoneNumber> GetAllPhoneNumbers()
        {
            return LoadAll();
        }

        public int CountPhoneNumbers()
        {
            return _context.Set<PHB_PhoneNumber>().Count();
        }

        public void AddPhoneNumber(PHB_PhoneNumber PHB_PhoneNumber)
        {
            Add(PHB_PhoneNumber);
            Commit();

        }

        public void DeletePhoneNumber(int Id)
        {
            DeleteWhere(c => c.id == Id);
            Commit();
        }

        public void UpdatePhoneNumber(PHB_PhoneNumber PHB_PhoneNumber)
        {
            Update(PHB_PhoneNumber);
            Commit();
        }
        
        public List<PHB_PhoneNumber> GetPhoneNumbersOrdered(string filter = null)
        {
            var record = _context.Set<PHB_PhoneNumber>()
               .OrderBy(c => c.id)
                .ToList();

            return record;
        }              
    }
}
