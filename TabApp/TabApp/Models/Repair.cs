using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabApp.Models
{
    public class Repair
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [DataType(DataType.Currency)]
        public int Cost { get; set; }

        public bool Warranty {get; set;}

        public String Status {get; set;}

        public ulong PickupCode {get; set;}

        public int? ItemID { get; set; }

        public Item Item { get; set; }

        public Invoice Invoice { get; set; }

        public ICollection<Service> Service { get; set; }

    }

}