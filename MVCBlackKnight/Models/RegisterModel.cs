using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlackKnight.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="UserNameis Required")]
        public string UserName { get; set; }//textbox
        public string Password { get; set; }//password
        [Compare("Password",ErrorMessage ="PAssword and Confirm Password mismatch ")]
        public string ConfirmPassword { get; set; }//password
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }//radio
        [Range(10000,20000,ErrorMessage =("10000-20000 is only allowed"))]
        public int Salary { get; set; }
        public string Gender { get; set; }//radio
        [StringLength(10,ErrorMessage ="More then 10 characters not allowed")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="only characters accepted")]
        public string Country { get; set; }//dropdownlist
        public bool   agreement { get; set; }//checkbox
    }
}