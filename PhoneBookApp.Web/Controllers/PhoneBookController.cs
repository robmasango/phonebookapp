using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Web.Models;
using PhoneBookApp.Model.Entities.System;
using System.Threading.Tasks;

namespace PhoneBookApp.Web.Controllers
{
  [Route("api/phonebook")]
  public class PhoneBookController : Controller
  {
    private readonly IPhoneBookRepository _PhoneBookApi;
    private readonly IPhoneNumberRepository _PhoneNumberApi;
    private readonly ILoggingRepository _loggingApi;

    public PhoneBookController(ILoggingRepository LoggingRepo, IPhoneBookRepository phonebookrepo, IPhoneNumberRepository phonenumrepo)
    {
      _PhoneNumberApi = phonenumrepo;
      _PhoneBookApi = phonebookrepo;
      _loggingApi = LoggingRepo;
    }

    #region PhoneBook

    [AllowAnonymous]
    [HttpGet("getPhoneBook")]
    public async Task<IActionResult> GetPhoneBook()
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneBook = await _PhoneBookApi.GetFirstPhoneBook();

        if (PhoneBook == null)
        {
          return NotFound(new { message = "Phone Books not found" });
        }
        else
        {

          PhoneBookViewModel item = new PhoneBookViewModel();

          item.MapSinglePhoneBook(PhoneBook);

          return new ObjectResult(item);
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [AllowAnonymous]
    [HttpGet("getPhoneBookByID")]
    public async Task<IActionResult> GetPhoneBookByID(int Id)
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneBook = await _PhoneBookApi.GetPhoneBookByID(Id);

        if (PhoneBook == null)
        {
          return NotFound(new { message = "Phone Books not found" });
        }
        else
        {

          PhoneBookViewModel item = new PhoneBookViewModel();

          item.MapSinglePhoneBook(PhoneBook);

          return new ObjectResult(item);
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [AllowAnonymous]
    [HttpGet("getPhoneBooks")]
    public async Task<IActionResult> GetPhoneBooks()
    {
      _ = new ObjectResult(false);

      try
      {

        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var PhoneBooks = await _PhoneBookApi.GetAllPhoneBooks();

        if (PhoneBooks == null)
        {
          return NotFound(new { message = "Phone Books not found" });
        }
        else
        {
          var item = PhoneBookViewModel.MultiplePhoneBooksMap(PhoneBooks);

          return new ObjectResult(item);
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpPost("addPhoneBook")]
    public async Task<IActionResult> AddPhoneBook([FromBody]PhoneBookViewModel AddPhoneBook)
    {
      _ = new ObjectResult(false);

      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        else
          await _PhoneBookApi.AddPhoneBook(AddPhoneBook.ReverseMap());

          return Ok(new { message = "Phone Book is added successfully." });
      }

      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpPost("updatePhoneBook")]
    public async Task<IActionResult> UpdatePhoneBook([FromBody]PhoneBookViewModel PhoneBook)
    {
      _ = new ObjectResult(false);

      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        else
        {
          var newPhoneBook = PhoneBook.ReverseMap();

          await _PhoneBookApi.UpdatePhoneBook(newPhoneBook);

          var PhoneBookvm = new PhoneBookViewModel(newPhoneBook);

          return Ok(new { message = "PhoneNumber is updated successfully." });

        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpDelete("deletePhoneBook")]
    public async Task<IActionResult> DeletePhoneBook(int Id)
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneBook = await _PhoneBookApi.GetPhoneBookByID(Id);

        if (PhoneBook == null)
        {
          return NotFound(new { message = "Phone Books not found" });
        }
        else
        {
          _PhoneBookApi.Delete(PhoneBook);

          return Ok(new { message = "PhoneNumber is deleted successfully." });

        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    #endregion

    #region PhoneNumber

    [AllowAnonymous]
    [HttpGet("getPhoneNumber")]
    public async Task<IActionResult> GetPhoneNumber(int Id)
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneNumber = await _PhoneNumberApi.GetPhoneNumberByID(Id);

        if (PhoneNumber == null)
        {
          return NotFound(new { message = "Phone Books not found" });
        }
        else
        {
          PhoneNumberViewModel item = new PhoneNumberViewModel(PhoneNumber);

          item.MapSinglePhoneNumber(PhoneNumber);

          return new OkObjectResult(item);
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [AllowAnonymous]
    [HttpGet("getAllPhoneNumbers")]
    public async Task<IActionResult> GetAllPhoneNumbers()
    {
      _ = new ObjectResult(false);

      try
      {

        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var PhoneNumbers = await _PhoneNumberApi.GetAllPhoneNumbers();

        if (PhoneNumbers == null)
        {
          return NotFound(new { message = "Phone Books not found" });
        }
        else
        {

          var items = PhoneNumberViewModel.MultiplePhoneNumberMap(PhoneNumbers);

          return new OkObjectResult(items);
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }


    [AllowAnonymous]
    [HttpGet("getPhoneBookNumbers")]
    public async Task<IActionResult> GetPhoneBookNumbers(int Id)
    {
      try
      {
        var PhoneNumber = await _PhoneNumberApi.GetPhoneNumberByPhoneBookID(Id);

        if (PhoneNumber == null)
        {
          return NotFound(new { message = "Phone numbers not found" });
        }
        else
        {
          var item = PhoneNumberViewModel.MultiplePhoneNumberMap(PhoneNumber);


          return new OkObjectResult(item);
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [HttpPost]
    [Route("addPhoneNumber")]
    public async Task<IActionResult> AddPhoneNumber([FromBody()]PhoneNumberViewModel item)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        else
        {
          var PhoneBook = await _PhoneBookApi.GetFirstPhoneBook();
          item.PhonebookId = PhoneBook.Id;
          await _PhoneNumberApi.AddPhoneNumber(item.ReverseMap());

          return Ok(new { message = "PhoneNumber is added successfully." });
        }

      }

      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpPut("updatePhoneNumber")]
    public async Task<IActionResult> UpdatePhoneNumber(int id, [FromBody()]PhoneNumberViewModel item)
    {
      try
      {
        if (!ModelState.IsValid || item == null || id == 0)
        {
          return BadRequest(ModelState);
        }

        else
        {
          var updateditem = item.ReverseMap();

          var phonebook = await _PhoneBookApi.GetFirstPhoneBook();
          var number = await _PhoneNumberApi.GetPhoneNumberByID(id);
          if (number == null)
          {
            return NotFound(new { message = "Phone number not found" });
          }

          number.PhonebookId = phonebook.Id;
          number.Name = updateditem.Name;
          number.Email = updateditem.Email;
          number.Number = updateditem.Number;

          await _PhoneNumberApi.UpdatePhoneNumber(number);

          var updatednumber = new PhoneNumberViewModel(number);

          return Ok(new { message = "PhoneNumber is updated successfully." });

        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpDelete("deletePhoneNumber")]
    public async Task<IActionResult> DeletePhoneNumber(int Id)
    {
      try
      {
        var PhoneNumber = await _PhoneNumberApi.GetPhoneNumberByID(Id);

        if (PhoneNumber == null)
        {
          return NotFound(new { message = "Phone numbers not found" });
        }
        else
        {
         await _PhoneNumberApi.DeletePhoneNumber(PhoneNumber.Id);

          return Ok(new { message = "PhoneNumber is deleted successfully." });
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        await _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    #endregion

  }
}
