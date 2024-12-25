using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminUserController : Controller
    {
        private readonly ShopContext sc = new ShopContext();
        public IActionResult Index()
        {
            return View(sc.Users.Where(x=>x.UserRole == 1).ToList());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = sc.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("UserID,UserName,UserSurname,UserEmail,UserPhone,UserRole,UserPassword")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                sc.Update(user);
                sc.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = sc.Users.FirstOrDefault(x => x.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = sc.Users.Find(id);
            if (user != null)
            {
                sc.Users.Remove(user);
            }

            sc.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
