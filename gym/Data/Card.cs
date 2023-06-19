using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Data
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
