using Guna.UI2.WinForms;
using gym.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym.Services
{
    public class CardService
    {
        public DatabaseContext db { get; set; }

        public CardService() {
            db = new DatabaseContext();
        }
        public void Create(string firstName, string lastName, string phone, double price, bool year, bool month)
        {
            var card = new Card();
            card.FirstName = firstName;
            card.LastName = lastName;
            card.Phone = phone;
            card.Price = price;
            if (year == true)
            {
                card.Type = "Year";
                card.ExpiresAt = DateTime.Now.AddMonths(12);
            }
            else if (month == true)
            {
                card.Type = "Month";
                card.ExpiresAt = DateTime.Now.AddMonths(1);
            }
            db.Cards.Add(card);
            db.SaveChanges();
        }
   
        public double GetTotalIncome() => db.Cards.Where(x => x.ExpiresAt >= DateTime.Now).Select(x => x.Price).Sum();
        public int GetInDateCards() => db.Cards.Where(x => x.ExpiresAt >= DateTime.Now).Count();
        public int GetExpiredCards() => db.Cards.Where(x => x.ExpiresAt < DateTime.Now).Count();
        public int Count() => db.Cards.Count();

        public List<Card> getAll() => db.Cards.ToList();
        public Card GetFirst() => db.Cards.FirstOrDefault();

        public void Renew(int id, bool year, bool month)
        {
            var card = db.Cards.FirstOrDefault(x => x.Id == id);
            if (year == true)
            {
                card.Type = "Year";
                card.ExpiresAt = card.ExpiresAt.AddMonths(12);
            }
            if (month == true)
            {
                card.Type = "Month";
                card.ExpiresAt = card.ExpiresAt.AddMonths(1);
            }
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var card = db.Cards.FirstOrDefault(x => x.Id == id);
            db.Cards.Remove(card);
            db.SaveChanges();
        }
    }
}
