using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaithMgmtAPI.Models
{
    public class Member
    {
        [Key]
        public int Id { get; private set; }

        public string Name { get; set; } = null!;
        public DateTime DateAdded { get; private set; }
        public List<int>? Requests { get; set; }
    }

}
