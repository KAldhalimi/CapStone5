using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StateManagmentLab.Models
{
    public class Registration
    {
        [Required]
        [RegularExpression(@"^[A-Z{1}]+[a-zA-z{1,30}]+$", ErrorMessage = "Please enter a valid name.")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9{5,30}]+@[a-zA-A0-9{5,10}]+\.[a-zA-Z0-9{2,3}]+$", ErrorMessage = "Incorrect E-mail Format!")]
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
       

        public Registration(string userName, string email, int age, string password)
        {

            UserName = userName;
            Email = email;
            Age = age;
            Password = password;
            
        }


        public Registration() { }
    }
}
    

