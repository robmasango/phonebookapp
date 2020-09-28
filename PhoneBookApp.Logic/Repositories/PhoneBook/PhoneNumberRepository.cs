using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        public async Task<PHB_PhoneNumber> GetPhoneNumberByID(int id)
        {
            return await FindSingle(id);
        }

        public async Task<List<PHB_PhoneNumber>> GetPhoneNumberByPhoneBookID(int PhoneBookID)
        {
          var PHB_PhoneNumber = await _context.Set<PHB_PhoneNumber>()
          .Where(x => x.phonebookid == PhoneBookID)
          .ToListAsync();

          return PHB_PhoneNumber;
        }

        public async Task<List<PHB_PhoneNumber>> GetAllPhoneNumbers()
        {
            return await LoadAll();
        }

        public async Task<int> CountPhoneNumbers()
        {
            return await _context.Set<PHB_PhoneNumber>().CountAsync();
        }

        public async Task AddPhoneNumber(PHB_PhoneNumber PHB_PhoneNumber)
        {
            Add(PHB_PhoneNumber);
            await Commit();

        }

        public async Task DeletePhoneNumber(int Id)
        {
            DeleteWhere(c => c.id == Id);
            await Commit();
        }

        public async Task UpdatePhoneNumber(PHB_PhoneNumber PHB_PhoneNumber)
        {
            Update(PHB_PhoneNumber);
            await Commit();
        }
        
        public async Task<List<PHB_PhoneNumber>> GetPhoneNumbersOrdered(string filter = null)
        {
            var record = await _context.Set<PHB_PhoneNumber>()
               .OrderBy(c => c.id)
                .ToListAsync();

            return record;
        }              
    }
}
