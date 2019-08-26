using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pollinator.Models
{
  public class PollinatorContext
  {
    public virtual DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuizQuestion> QuizQuestion { get; set; }

    public PollinatorContext(DbContextOptions options){ }
  }
}