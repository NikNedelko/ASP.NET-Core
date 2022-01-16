using System;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        // Пожалуйста, введите свое имя 
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\0.+\\..+",
        ErrorMessage = "Please enter a valid email address")]
        // Пожалуйста, введите свой адрес электронной почты 
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        // Пожалуйста, введите свой номер телефона 
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please specify whether you'll attend")]
        // Пожалуйста, укажите, примете ли участие 
        public bool? WillAttend { get; set; }
    }
}