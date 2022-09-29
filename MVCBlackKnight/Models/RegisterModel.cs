using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlackKnight.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }//textbox
        public string Password { get; set; }//password
        public string Gender { get; set; }//radio
        public string Country { get; set; }//dropdownlist
        public bool agreement { get; set; }//checkbox
    }
}