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



//public static class MemberEndpoints
//{
//	public static void MapMemberEndpoints (this IEndpointRouteBuilder routes)
//    {
//        var group = routes.MapGroup("/api/Member").WithTags(nameof(Member));

//        group.MapGet("/", async (FaithMgmtContext db) =>
//        {
//            return await db.Members_Table.ToListAsync();
//        })
//        .WithName("GetAllMembers")
//        .WithOpenApi();

//        group.MapGet("/{id}", async Task<Results<Ok<Member>, NotFound>> (int id, FaithMgmtContext db) =>
//        {
//            return await db.Members_Table.AsNoTracking()
//                .FirstOrDefaultAsync(model => model.Id == id)
//                is Member model
//                    ? TypedResults.Ok(model)
//                    : TypedResults.NotFound();
//        })
//        .WithName("GetMemberById")
//        .WithOpenApi();

//        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Member member, FaithMgmtContext db) =>
//        {
//            var affected = await db.Members_Table
//                .Where(model => model.Id == id)
//                .ExecuteUpdateAsync(setters => setters
//                  .SetProperty(m => m.Id, member.Id)
//                  .SetProperty(m => m.Name, member.Name)
//                  .SetProperty(m => m.Email, member.Email)
//                  .SetProperty(m => m.DateAdded, member.DateAdded)
//                  .SetProperty(m => m.Requests, member.Requests)
//                  );
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("UpdateMember")
//        .WithOpenApi();

//        group.MapPost("/", async (Member member, FaithMgmtContext db) =>
//        {
//            db.Members_Table.Add(member);
//            await db.SaveChangesAsync();
//            return TypedResults.Created($"/api/Member/{member.Id}",member);
//        })
//        .WithName("CreateMember")
//        .WithOpenApi();

//        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, FaithMgmtContext db) =>
//        {
//            var affected = await db.Members_Table
//                .Where(model => model.Id == id)
//                .ExecuteDeleteAsync();
//            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
//        })
//        .WithName("DeleteMember")
//        .WithOpenApi();
//    }
//}
//}
