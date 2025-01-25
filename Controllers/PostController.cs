using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Models;

namespace PostManagementSystem.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public IActionResult Index()
        {
            var r = _context.posts.Where(p=>!p.IsDeleted)
                .Include(p=>p.User).ToList();
            return View(r);
        }

     
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

      
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.users.Where(p=>!p.IsDeleted), "ID", "Email");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,urlImage,Description,PublishDate,IsDeleted")] Post post)
        {
           
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
           
           
        }

        
        public async Task<IActionResult> Edit(long id)
        {
       

            var post = await _context.posts.FindAsync(id);
         
            ViewData["UserID"] = new SelectList(_context.users, "ID", "Email", post.UserID);
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ID,UserID,urlImage,Description,PublishDate,IsDeleted")] Post post)
        {
                _context.posts.Update(post);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            
                
        }    


        
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var post = await _context.posts.FindAsync(id);
            if (post != null)
            {
                _context.posts.Remove(post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(long id)
        {
            return _context.posts.Any(e => e.ID == id);
        }
    }
}
