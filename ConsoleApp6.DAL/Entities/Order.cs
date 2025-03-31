using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public DateTime DateCreate { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
