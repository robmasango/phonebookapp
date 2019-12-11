using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Model;
using PhoneBookApp.Model.Entities.System;

namespace PhoneBookApp.Logic.Repositories
{
  public class LoggingRepository : EntityBaseRepository<SYS_Error>, ILoggingRepository
  {
    public LoggingRepository(PhoneBookAppContext context)
        : base(context)
    { }

    public override void Commit()
    {
      try
      {
        base.Commit();
      }
      catch { }
    }
  }
}