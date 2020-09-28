using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBookApp.Model.Entities.PhoneBook;
using System.Threading.Tasks;

namespace PhoneBookApp.Model
{
  public class PhoneBookAppDbInitializer
  {
    private static PhoneBookAppContext _context;
    private readonly ILogger _logger;

    public PhoneBookAppDbInitializer(PhoneBookAppContext context, ILogger<PhoneBookAppDbInitializer> logger)
    {
      _context = context;
      _logger = logger;
    }
    public async Task SeedAsync()
    {
      await _context.Database.MigrateAsync().ConfigureAwait(false);

      await AddPhoneBook();
      await AddPhoneNumber();
    }
    private async Task AddPhoneBook()
    {
      if (!await _context.PHB_PhoneBook.AnyAsync())
      {
        PHB_PhoneBook phonebook = new PHB_PhoneBook() { Name = "Ureka PhoneBook"};

        await _context.PHB_PhoneBook.AddAsync(phonebook);

        await _context.SaveChangesAsync();
      }

    }

    private async Task AddPhoneNumber()
    {
      if (!await _context.PHB_PhoneNumber.AnyAsync())
      {
        PHB_PhoneNumber num = new PHB_PhoneNumber()
        {
          PhoneBookId = 1,
          Name = "Robert One",
          Email = "rob1@gmail.com",
          Number = "0727601650",
        };

        PHB_PhoneNumber num1 = new PHB_PhoneNumber()
        {
          PhoneBookId = 1,
          Name = "Robert Two",
          Email = "rob2@gmail.com",
          Number = "0727601651",
        };

        PHB_PhoneNumber num2 = new PHB_PhoneNumber()
        {
          PhoneBookId = 1,
          Name = "Robert Three",
          Email = "rob3@gmail.com",
          Number = "0727601652",
        };

        await _context.PHB_PhoneNumber.AddAsync(num);
        await _context.PHB_PhoneNumber.AddAsync(num1);
        await _context.PHB_PhoneNumber.AddAsync(num2);

        await _context.SaveChangesAsync();
      }
    }



  }
}

