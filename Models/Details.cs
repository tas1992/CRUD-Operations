using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace form_simple.Models
{
    public class Details
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Name required. ")]
      public  string name { get; set; }
        [Required(ErrorMessage = "Age required. ")]
       public  int age { get; set; }
 
       public  string gender { get; set; }
        [Required(ErrorMessage = "Email address required. ")]
        [EmailAddress(ErrorMessage ="Invalid email address. ")]
       public string email { get; set; }

    }
}
