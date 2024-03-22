using System.ComponentModel.DataAnnotations;

namespace FaithMgmtAPI.Models
{
    public class Member
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime DateAdded { get; private set; }
        public List<int>? Requests { get; set; }
    }
}