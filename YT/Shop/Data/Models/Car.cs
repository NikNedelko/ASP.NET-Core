using System;
using Shop.Data.Models;
namespace Shop.Data.Models
{
     public class Car
    {
        public int id { set; get; } // идентификатор конкретного объекта
        public string name { set; get; } // имя 
        public string shortDesc { set; get; }//короткое описание 
        public string longDesc { set; get; }//длинное описание
        public string img { get; set; } // для указания юрл адресса где находится картинка
        public ushort price { set; get; } // цена 
        public bool isFavourite { set; get; } //если тру, то отображается на главной
        public bool available { set; get; } //есть ли  данный товар на складе
        public int categoryID { set; get; } // категория товара
        public virtual Category Category { set; get; } // создаём объект на основе определённой категории, со всеми значениями +
        // которые есть у нас в классе Category
    }

}