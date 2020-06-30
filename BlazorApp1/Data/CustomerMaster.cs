using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class CustomerMaster
    {
        [Key]
        public string CustCd { get; set; }
        public string CustName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string InsertBy { get; set; } 
    }
}
