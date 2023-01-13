using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class Transaction
    {

        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public int Amount { get; set; }

        public string? ExpName { get; set; }


        public string? ExpDesc { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        
    }
}
