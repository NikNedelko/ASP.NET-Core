using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models; 
using System.Linq;
/// <summary>
/// Здесь имеется единственный метод действия Index (), который получает все объ­екты модели и передает их методу 
/// View () для визуализации стандартного представ­ления.
/// </summary>
namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()=> View(SimpleRepository.SharedRepository.Products.Where(p => p. Price < 50)) ;
    }
}