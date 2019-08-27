using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pollinator.Models
{
  public class PollinatorContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Response> Responses {get; set;}
    public DbSet<QuizResponse> QuizResponse {get; set;}

    public PollinatorContext(DbContextOptions options): base(options){ }
  }
}