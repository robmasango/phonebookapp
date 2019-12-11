using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PhoneBookApp.Logic.Abstract;
using PhoneBookApp.Web.Models;
using PhoneBookApp.Model.Entities.System;

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
    public IActionResult GetPhoneBook()
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneBook = _PhoneBookApi.GetFirstPhoneBook();

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [AllowAnonymous]
    [HttpGet("getPhoneBookByID")]
    public IActionResult GetPhoneBookByID(int Id)
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneBook = _PhoneBookApi.GetPhoneBookByID(Id);

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [AllowAnonymous]
    [HttpGet("getPhoneBooks")]
    public IActionResult GetPhoneBooks()
    {
      _ = new ObjectResult(false);

      try
      {

        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var PhoneBooks = _PhoneBookApi.GetAllPhoneBooks();

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpPost("addPhoneBook")]
    public IActionResult AddPhoneBook([FromBody]PhoneBookViewModel AddPhoneBook)
    {
      _ = new ObjectResult(false);

      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        else
          _PhoneBookApi.AddPhoneBook(AddPhoneBook.ReverseMap());

          return Ok(new { message = "Phone Book is added successfully." });
      }

      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpPost("updatePhoneBook")]
    public IActionResult UpdatePhoneBook([FromBody]PhoneBookViewModel PhoneBook)
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

          _PhoneBookApi.Update(newPhoneBook);

          var PhoneBookvm = new PhoneBookViewModel(newPhoneBook);

          return Ok(new { message = "PhoneNumber is updated successfully." });

        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpDelete("deletePhoneBook")]
    public IActionResult DeletePhoneBook(int Id)
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneBook = _PhoneBookApi.GetPhoneBookByID(Id);

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    #endregion

    #region PhoneNumber

    [AllowAnonymous]
    [HttpGet("getPhoneNumber")]
    public IActionResult GetPhoneNumber(int Id)
    {
      _ = new ObjectResult(false);

      try
      {
        var PhoneNumber = _PhoneNumberApi.GetPhoneNumberByID(Id);

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [AllowAnonymous]
    [HttpGet("getAllPhoneNumbers")]
    public IActionResult GetAllPhoneNumbers()
    {
      _ = new ObjectResult(false);

      try
      {

        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        var PhoneNumbers = _PhoneNumberApi.GetAllPhoneNumbers();

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }


    [AllowAnonymous]
    [HttpGet("getPhoneBookNumbers")]
    public IActionResult GetPhoneBookNumbers(int Id)
    {
      try
      {
        var PhoneNumber = _PhoneNumberApi.GetPhoneNumberByPhoneBookID(Id);

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
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    [HttpPost]
    [Route("addPhoneNumber")]
    public IActionResult AddPhoneNumber([FromBody()]PhoneNumberViewModel item)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }
        else
        {
          var PhoneBook = _PhoneBookApi.GetFirstPhoneBook();
          item.phonebookid = PhoneBook.id;
          _PhoneNumberApi.AddPhoneNumber(item.ReverseMap());

          return Ok(new { message = "PhoneNumber is added successfully." });
        }

      }

      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpPut("updatePhoneNumber")]
    public IActionResult UpdatePhoneNumber(int id, [FromBody()]PhoneNumberViewModel item)
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

          var phonebook = _PhoneBookApi.GetFirstPhoneBook();
          var number = _PhoneNumberApi.GetPhoneNumberByID(id);
          if (number == null)
          {
            return NotFound(new { message = "Phone number not found" });
          }

          number.phonebookid = phonebook.id;
          number.name = updateditem.name;
          number.email = updateditem.email;
          number.number = updateditem.number;

          _PhoneNumberApi.UpdatePhoneNumber(number);

          var updatednumber = new PhoneNumberViewModel(number);

          return Ok(new { message = "PhoneNumber is updated successfully." });

        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }

    }

    [AllowAnonymous]
    [HttpDelete("deletePhoneNumber")]
    public IActionResult DeletePhoneNumber(int Id)
    {
      try
      {
        var PhoneNumber = _PhoneNumberApi.GetPhoneNumberByID(Id);

        if (PhoneNumber == null)
        {
          return NotFound(new { message = "Phone numbers not found" });
        }
        else
        {
          _PhoneNumberApi.DeletePhoneNumber(PhoneNumber.id);

          return Ok(new { message = "PhoneNumber is deleted successfully." });
        }
      }
      catch (Exception ex)
      {
        _loggingApi.Add(new SYS_Error() { Message = ex.Message, StackTrace = ex.StackTrace, CreatedDate = DateTime.Now });
        _loggingApi.Commit();

        return NotFound(new { message = "An error occured" });
      }
    }

    #endregion

  }
}
