using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class TestDataBaseClass
    {
        public int ID { get; set; }
        public int passport_series { get; set; }
        public int passport_number { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public DateTime birthday { get; set; }
        public string tel_number { get; set; }
    }
    public class MovieDBContext : DbContext
    {
        public DbSet<TestDataBaseClass> Test { get; set; }
    }

}