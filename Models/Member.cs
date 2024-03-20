using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaithMgmtAPI.Models
{
    public class Member(string name)
    {
        [Key]
        public int Id { get; }

        public string Name { get; set; } = name;
        public DateTime DateAdded { get; }
        public List<int>? Requests { get; set; }
    }
}
