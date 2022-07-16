#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class GolfCourse
{
    [Key]


    public int CourseId {get; set; }

        
    
    [Required(ErrorMessage ="Please Input Course Name")]
    [MinLength(2,ErrorMessage = "Please add a course name")]
    [Display(Name = "Course Name")]

    public string CourseName {get; set; }

    [Required(ErrorMessage = "Please input course Par Score")]
    [Range(20, 76, ErrorMessage = "Input a course Par ")]
    [Display(Name = "Course Par")]

    public int CoursePar {get; set; }

    [Required(ErrorMessage = "Please input Rating")]
    [Range(55, 155, ErrorMessage = "Input a Rating between 55 and 155")]
    [Display(Name = "Course Rating")]

    public double CourseRating {get; set; }

    [Required(ErrorMessage = "Please input Slope")]
    [Range(55, 155, ErrorMessage = "Input a Slope between 55 and 155")]
    [Display(Name = "Course Slope")]

    public double CourseSlope {get; set; }

    public int UserId {get; set; }

    public User? Player {get; set;}

    

    
}

