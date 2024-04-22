#nullable disable
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using TechnoWeb.Models;

namespace TechnoWeb.Controllers
{
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly DataContext _db;

        public CartController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(GetCart());
        }

        [HttpPost]
        public IActionResult AddToCart(int? Id)
        {
            if (Id.HasValue)
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == Id.Value);
                if (product != null)
                {
                    var cart = GetCart();
                    cart.AddProduct(product, 1); // Sepete ürün ekleniyor
                    HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart)); // Oturum güncelleniyor
                    return RedirectToAction("Index", "Cart"); // Sepet sayfasına yönlendiriliyor
                }
            }
            return RedirectToAction("Index", "Home"); // Hata durumunda ana sayfaya yönlendiriliyor
        }



        [HttpPost("[action]")]
        public IActionResult RemoveToCart(int? Id)
        {
            if (Id.HasValue)
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == Id.Value);
                if (product != null)
                {
                    var cart = GetCart();
                    cart.DeleteProduct(product);
                    HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart)); // Oturum güncelleniyor
                }
            }
            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            Cart cart;
            if (!string.IsNullOrEmpty(cartJson))
            {
                cart = JsonConvert.DeserializeObject<Cart>(cartJson);
            }
            else
            {
                cart = new Cart();
                HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            }
            return cart;
        }

        public IActionResult Summary()
        {
            return View(GetCart());
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
