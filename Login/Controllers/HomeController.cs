using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoginPage()
        {

            IEnumerable<Register> u = _db.Registers.ToList();
            return View(u);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO dto )
        {
           
               string username = dto.Username;
               string password = dto.Password;

                var singleCustomer = _db.Registers
                .SingleOrDefault(c => c.Name == username && c.Password == password);

                if (singleCustomer != null)
                {
                return RedirectToAction("LoginPage");

                }
                else
                {
                TempData["ToastError"] = "Invalid password ";
                return RedirectToAction("Login");

            }
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);

            }
            _db.Registers.Add(register);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Successfully Created";
            return RedirectToAction("Form");
        }

        public IActionResult Table()
        {
            IEnumerable<Register> userlist = _db.Registers.ToList();
            return View(userlist);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Table");

            }
            var a = _db.Registers.Find(id);

            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Register register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            _db.Registers.Update(register);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Edited";
            return RedirectToAction("Table");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return RedirectToAction("Table");
            }
            var a = _db.Registers.Find(id);
            return View(a);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {

            var userdelete = _db.Registers.Find(id);
            if (userdelete == null)
            {
                return NotFound();
            }
            _db.Registers.Remove(userdelete);
            _db.SaveChanges();
            TempData["SweetWarning"] = "Deleted";
            return RedirectToAction("Table");
        }

        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);

            }
            _db.Books.Add(book);
            _db.SaveChanges();
            TempData["SweetSuccess"] = "Successfully Created";
            return RedirectToAction("AddBook");
        }


        public IActionResult ShowBook()
        {
            IEnumerable<Book> booklist = _db.Books.ToList();
            return View(booklist);
        }

       
       
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}