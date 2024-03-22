using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FaithMgmtAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

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