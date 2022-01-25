
using System.Collections.Generic;
/// <summary>
/// Класс SimpleRepository хранит объекты модели в памяти, т.е. любые внесенные в модель изменения утрачиваются, 
/// когда приложение останавливается или переза­ пускается. Для примеров, приводимых в настоящей главе, непостоянного 
/// хранилища вполне достаточно, но такой подход не может применяться во многих реальных про­ ектах; в главе 8 рассматривается 
/// пример создания хранилища, которое запоминает объекты модели на постоянной основе, используя реляционную базу данных.
/// </summary>
namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();
        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialltems = new[] {
            new Product{Name = "Kayak" , Price = 275M },
            new Product{Name = "Lifejacket", Price = 48.95M},
            new Product{Name = "Soccer ball", Price = 19.50M },
            new Product{Name = "Corner flag", Price = 34.95M }
            };
            foreach (var p in initialltems)
            {
                AddProduct(p);
            }
        }
        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
