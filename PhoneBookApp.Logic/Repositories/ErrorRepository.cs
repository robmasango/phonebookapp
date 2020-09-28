using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model;
using PhoneBookApp.Model.Entities.System;
using System.Threading.Tasks;

namespace PhoneBookApp.Logic.Repositories
{
  public class LoggingRepository : EntityBaseRepository<SYS_Error>, ILoggingRepository
  {
    public LoggingRepository(PhoneBookAppContext context)
        : base(context)
    { }

    public async virtual new Task Commit()
    {
      try
      {
                await base.Commit();
      }
      catch { }
    }
  }
}