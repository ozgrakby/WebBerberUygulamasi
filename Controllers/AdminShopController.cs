using Microsoft.AspNetCore.Mvc;
using WebBerberUygulamasi.Models;

namespace WebBerberUygulamasi.Controllers
{
    public class AdminShopController : Controller
    {
        ShopContext sc = new ShopContext();
        public IActionResult Index()
        {
            return View(sc.Shop.FirstOrDefault());
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = sc.Shop.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ShopID,ShopOpening,ShopClosing")] Shop shop)
        {
            if (id != shop.ShopID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (shop.ShopOpening >= shop.ShopClosing)
                {
                    TempData["msj"] = "Açılış zamanı kapanış zamanından önce olmalı!!";
                    return View(shop);
                }
                sc.Update(shop);
                sc.SaveChanges();

                return RedirectToAction(nameof(Index), sc.Shop.FirstOrDefault());
            }
            return View(shop);
        }
    }
}
