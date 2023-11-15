using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nirsman.Infrasturcture;
using Nirsman.Models;

namespace Nirsman.Controllers
{
    public class StoreController : Controller
    {
        private readonly DataContext _context;

        public StoreController(DataContext context)
        {
            _context = context;

        }

        public async Task<Product> LoadData(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // Получаем все товары из базы данных

            return View(products);
        }

        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Создайте список для хранения данных изображений
                if (product.ImageFile != null && product.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await product.ImageFile.CopyToAsync(ms);
                        product.Image = ms.ToArray();
                    }
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return View(product);
        }

        public async Task<IActionResult> Details(long id)
        {

            var product = await LoadData(id);

            if (product == null)
            {
                return NotFound(); // Если продукт с указанным id не найден, возвращаем HTTP 404
            }

            return View(product);
        }

        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");  // Redirect to the admin page after deletion
        }
    }
}
