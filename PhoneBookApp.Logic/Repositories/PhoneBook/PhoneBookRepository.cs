using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model.Entities.PhoneBook;
using PhoneBookApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PHB_PhoneBook> GetPhoneBookByID(int id)
        {
            return await FindSingle(subject => subject.Id == id);
        }

        public async Task<List<PHB_PhoneBook>> GetAllPhoneBooks()
        {
            return await LoadAll();
        }

        public async Task<PHB_PhoneBook> GetFirstPhoneBook()
        {
            return await FindSingle();
        }

        public async Task<PHB_PhoneBook> GetPhoneBook(string name)
        {
            return await FindSingle(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<int> CountPhoneBooks()
        {
            return await _context.Set<PHB_PhoneBook>().CountAsync();
        }

        public async Task AddPhoneBook(PHB_PhoneBook PHB_PhoneBook)
        {
            Add(PHB_PhoneBook);
            await Commit();
        }

        public async Task DeletePhoneBook(int Id)
        {
            DeleteWhere(c => c.Id == Id);
            await Commit();
        }

        public async Task UpdatePhoneBook(PHB_PhoneBook PHB_PhoneBook)
        {
            Update(PHB_PhoneBook);
            await Commit();
        }
        

        public async Task<List<PHB_PhoneBook>> GetPhoneBooksOrdered(string filter = null)
        {
            var record = await _context.Set<PHB_PhoneBook>()
               .OrderBy(c => c.Id)
                .ToListAsync();

            return record;
        }                    
    }
}
