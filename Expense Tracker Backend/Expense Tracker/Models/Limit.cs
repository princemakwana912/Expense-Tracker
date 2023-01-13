using System.ComponentModel.DataAnnotations;
namespace Expense_Tracker.Models

{
    public class Limit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Value { get; set; }
    }
}
