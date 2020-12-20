using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Dto
{
    public class BillsDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public double TotalAmount { get; set; }
        public double KdvAmount { get; set; }
        public double KdvRate { get; set; }
        public string Currency { get; set; }
        public int BillNo { get; set; }
        public DateTime? BillDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string IdentityUserId { get; set; }
    }
}
