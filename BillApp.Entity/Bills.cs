using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Entity
{
    public class Bills
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public double  TotalAmount { get; set; }
        public double KdvAmount { get; set; }
        public double KdvRate { get; set; }
        public string Currency { get; set; }
        public int BillNo { get; set; }
        public DateTime? BillDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual IdentityUser UserId { get; set; }

    }
}
