#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Association
{
    [Key]

    public int AssociationId {get; set;}

    public int CourseId {get; set;}

    public int UserId {get; set; }

    public int ScoreId {get; set; }

    public GolfCourse? Course {get; set;}

    public User? Player {get; set; }

    public GolfScore? Score {get; set; }
}