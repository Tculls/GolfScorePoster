#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GolfScore

{
    [Key]

    public int ScoreId {get; set; }

    [Required(ErrorMessage = "Please input date")]
    [PastDate(ErrorMessage = "You are not from the future")]
    [Display(Name = "Date Round Played")]

    public DateTime DatePlayed {get; set; }


    [Required(ErrorMessage = "Please select tees played")]
    [MinLength(1, ErrorMessage ="Please select tees played")]
    
    public string TeesPlayed {get; set; }

    [Required(ErrorMessage = "Please input score")]
    [Range(27, 150, ErrorMessage = "Please input a score between 27 to 150")]
    [Display(Name = "Round Score")]

    public int RoundScore {get; set; }

    [Required(ErrorMessage = "Please indicate if it was 9 or 18 holes")]
    [MinLength(1, ErrorMessage = "Please select 9 or 18")]
    [Display(Name = "Number of Holes")]

    public int NineOrEighteen {get; set; }


    [InverseProperty("Player's Score")]
    public List<User> UserId {get; set; } = new List<User>();

    public int CourseId {get; set; }
    public User? Player {get; set; }

    public GolfCourse CoursePlayed {get; set; }



}