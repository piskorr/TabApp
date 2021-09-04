using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabApp.Models
{
    public class Message
    {
        public int ID { get; set; }

        public String Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Person Sender { get; set; }

        public Person Addressee { get; set; }

    }

}