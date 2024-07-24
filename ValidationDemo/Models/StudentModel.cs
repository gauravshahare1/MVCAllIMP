
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ValidationDemo.common;

namespace ValidationDemo.Models
{
    public class StudentModel
    {
        public int Rollnumber { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        //[MinLength(2)]
        //[MaxLength(50)]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Name betweem 2 to 50 chareater")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage ="Enter Valid Number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        //[RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", ErrorMessage ="Please valid Email")]
        //[EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Pleasr Enter Valid EMail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Age")]
        [Range(1,150, ErrorMessage ="PLease Enter Valid Age")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
       // [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "The password must contain at least one lowercase letter, one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password again")]
        [Compare("Password", ErrorMessage ="Password and Confirm Password should be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Admission Date")]
        [DisplayName("Admission Date")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter Admission Date")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataValidationAttribute(ErrorMessage ="Admission Date should be less todays date")]
        public DateTime? AdmissionDate { get; set; }
    }
}
