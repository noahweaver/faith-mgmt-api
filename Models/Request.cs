using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FaithMgmtAPI.Models
{
    public class Request(int id, string prayerRequest, int? memberId = null, string? name = null, DateTime? createdAt = null)
    {
        [Key]
        public int Id { get; } = id;
        
        public int? MemberId { get; set; } = memberId;

        public string? Name { get; set; } = name;
        public string PrayerRequest { get; set; } = prayerRequest;

        public DateTime? CreatedAt { get; } = createdAt;

    }
}
