using System;
using System.ComponentModel.DataAnnotations;

namespace TabApp.Models
{
    public class PersonWorker
    {
        public int ID { get; set; }
        public Person Person { get; set; }
        public PersonWorker Worker { get; set; }
    }

}