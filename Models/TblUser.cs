using System;
using System.Collections.Generic;

#nullable disable

namespace form_simple.Models
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
