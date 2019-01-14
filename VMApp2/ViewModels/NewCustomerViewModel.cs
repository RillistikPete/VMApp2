using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VMApp2.Models;

namespace VMApp2.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}