using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имени не более 15 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина фамилии не более 15 символов")]
        public string surname { get; set; }

        [Display(Name = "Введите адресс")]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина адресса не более 30 символов")]
        public string adress { get; set; }

        [Display(Name = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина телефона не более 20 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите email")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина почты не более 25 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}