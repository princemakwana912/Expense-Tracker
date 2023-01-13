using System.ComponentModel.DataAnnotations;
namespace Expense_Tracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? Name { get; set; }
        public int Limit { get; set; }
    }
}
