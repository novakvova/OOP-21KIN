using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfTest.Entities;

[Table("Tests")]
public class TestEntity
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Title { get; set; } = null!;

    [StringLength(1000)]
    public string? Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

    [Range(1, 60)]
    public int? TimeLimitMinutes { get; set; }

    public ICollection<QuestionEntity> Questions { get; set; } = null!;
}
