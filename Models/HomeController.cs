using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Models;

namespace PostManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var r = _context.users.Where(p=>!p.IsDeleted).ToList();
            return View(r);
        }
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.users.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException!=null&&ex.InnerException.Message.Contains("unique"))
                    {
                        ModelState.AddModelError("", "this UserName Has been Taken");
                    }
                    else
                    {
                        ModelState.AddModelError("", "somthing is wrong please try later");

                    }
                }
            }
            return View(user);
        }
        public IActionResult EditUser(long id) 
        {
            var r = _context.users.Find(id);
            return View(r);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    _context.users.Update(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    if (true)
                    {
                        ModelState.AddModelError("", "this UserName Has been Taken");
                    }
                    else
                    {
                        ModelState.AddModelError("", "somthing is wrong try later");
                    }
                }
            }
            return View(user);
        }
        public async Task<IActionResult> DeleteUser(long id) 
        {
            var r= _context.users.Find(id);
            r.IsDeleted=true;
            _context.users.Update(r);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        public IActionResult DetailsUser(long id)
        {
            var r=_context.users.Find(id);
            return View(r);
            
        }



            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
