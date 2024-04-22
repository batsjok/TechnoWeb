using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechnoWeb.Models;

namespace TechnoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var urunler = _context.Products.
            Where(i => i.IsHome && i.IsApproved)
            .Select(i => new ProductModel()   //veritabanından gelen datayı ProductModel içerisine pakaetleyip koşullarımızı yazıyoruz
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 45) + "..." : i.Description,
                Price = i.Price,
            }).ToList();

            return View(urunler);


        }



        public IActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id == id).FirstOrDefault());
        }

        public IActionResult List(int? id)
        {
            var viewModel = new ProductCategoryViewModel
            {
                // Tüm ürünleri listeye ekleyin
                Products = _context.Products
                    .Where(i => i.IsApproved)
                    .Select(i => new ProductModel()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description.Length > 50 ? i.Description.Substring(0, 45) + "..." : i.Description,
                        Price = i.Price,
                        CategoryId = i.CategoryId // Ürünlerin kategori kimliğini de dahil edin
                    }).ToList(),

                // Tüm kategorileri listeye ekleyin
                Categories = _context.Categories
                    .Select(i => new CategoryModel()
                    {
                        Id = i.Id,
                        Name = i.Name
                    }).ToList()
            };

            // Eğer bir id belirtilmişse, sadece o kategoriye ait ürünleri filtreleyin
            if (id != null)
            {
                viewModel.Products = viewModel.Products.Where(i => i.CategoryId == id).ToList();
            }

            return View(viewModel);
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
