using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaithMgmtAPI.Models
{
    public class Request
    {
        [Key]
        public int Id { get; private set; }
        
        public int? MemberId { get; set; }

        public string? Name { get; set; }
        public string PrayerRequest { get; set; } = null!;

        public DateTime? CreatedAt { get; private set; }

    }
}
