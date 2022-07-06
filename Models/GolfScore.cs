#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GolfScore

{
    [Key]

    public int ScoreId {get; set; }
    
    [Required(ErrorMessage ="Please Input Course Name")]
    [MinLength(2,ErrorMessage = "Please add a course name")]
    [Display(Name = "Course Name")]

    public string CourseName {get; set; }

    [Required(ErrorMessage = "Please input date")]
    [PastDate(ErrorMessage = "You are not from the future")]
    [Display(Name = "Date Round Played")]

    public DateTime DatePlayed {get; set; }

    [Required(ErrorMessage = "Please input Rating")]
    [Range(55, 155, ErrorMessage = "Input a Rating between 55 and 155")]
    [Display(Name = "Course Rating")]

    public int CourseRating {get; set; }

    [Required(ErrorMessage = "Please input Slope")]
    [Range(55, 155, ErrorMessage = "Input a Slope between 55 and 155")]
    [Display(Name = "Course Slope")]

    public int CourseSlope {get; set; }

    [Required(ErrorMessage = "Please input score")]
    [Range(27, 150, ErrorMessage = "Please input a score between 27 to 150")]
    [Display(Name = "Round Score")]

    public int RoundScore {get; set; }

    [Required(ErrorMessage = "Please indicate if it was 9 or 18 holes")]
    [Range(1,20, ErrorMessage ="Please choose 9 or 18")]
    [Display(Name = "Number of Holes")]

    public int NineOrEighteen {get; set; }



}