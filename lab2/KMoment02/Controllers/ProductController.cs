using System.Text.Json;
using KMoment02.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace KMoment02.Controllers
{
    public class ProductController : Controller
    {
        // Sökväg till JSON filen där produkterna lagras
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "mtcars.json");

        // visa alla produkter
        public IActionResult AllProducts()
        {
            
            ViewBag.Message = "Välkommen till vår webbsida!, här kan du hitta alla produkterna.";
            ViewBag.Year = DateTime.Now;

            // Hämtar alla produkter från JSON filen
            List<Products> allProducts = getAllProducts();

            // Returnerar vyn med produktlistan
            return View(allProducts);
        }

        // visa formuläret för att skapa en ny produkt
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View();
        }

        // hantera POST begäran när en ny produkt skapas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products product)
        {
            if (ModelState.IsValid) // Kontrollerar om modellen är giltig
            {
                List<Products> allProducts = getAllProducts();

                // ett nytt unikt ID till produkten
                if (allProducts.Any())
                    product.id = allProducts.Max(p => p.id) + 1;
                else
                    product.id = 1;

                // lägga till den nya produkten i listan och sparar till JSON filen
                allProducts.Add(product);
                SaveProducts(allProducts);

                return RedirectToAction(nameof(AllProducts));
            }

            // Om modellen inte är giltig returneras vyn med felmeddelanden
            return View(product);
        }

        //  visa formuläret för att redigera en produkt
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            List<Products> allProducts = getAllProducts();
            Products? productToEdit = allProducts.FirstOrDefault(p => p.id == id);

            if (productToEdit == null)
                return NotFound(); // Returnerar fel om produkten inte hittas

            return View(productToEdit);
        }

        //hantera POST begäran när en produkt uppdateras
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products updatedProduct)
        {
            if (ModelState.IsValid) // Kontrollerar om modellen är giltig
            {
                List<Products> allProducts = getAllProducts();
                Products? existingProduct = allProducts.FirstOrDefault(p => p.id == updatedProduct.id);

                if (existingProduct != null)
                {
                    // Uppdaterar produktens egenskaper
                    existingProduct.name = updatedProduct.name;
                    existingProduct.price = updatedProduct.price;
                    existingProduct.imgUrl = updatedProduct.imgUrl;
                    existingProduct.description = updatedProduct.description;

                    // Sparar den uppdaterade listan till JSON filen
                    SaveProducts(allProducts);
                }

                return RedirectToAction(nameof(AllProducts));
            }

            return View(updatedProduct);
        }

        //  hantera POST begäran när en produkt raderas
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            List<Products> allProducts = getAllProducts();
            Products? productToDelete = allProducts.FirstOrDefault(p => p.id == id);

            if (productToDelete != null)
            {
                // Tar bort produkten från listan och sparar till JSON filen
                allProducts.Remove(productToDelete);
                SaveProducts(allProducts);
            }

            return RedirectToAction(nameof(AllProducts));
        }

        // metod hämtar alla produkter från JSON filen
        private List<Products> getAllProducts()
        {
            if (!System.IO.File.Exists(filePath))
                return new List<Products>();

            string json = System.IO.File.ReadAllText(filePath);
            return string.IsNullOrEmpty(json) ? new List<Products>() : JsonConvert.DeserializeObject<List<Products>>(json);
        }

        // Metod sparar produktlistan till JSON filen
        private void SaveProducts(List<Products> products)
        {
            string newJson = JsonConvert.SerializeObject(products, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, newJson);
        }
    }
}