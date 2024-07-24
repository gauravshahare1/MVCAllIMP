using System.ComponentModel.DataAnnotations;

namespace ValidationDemo.common
{
    public class DataValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime today = DateTime.Now;
            DateTime inputDate = (DateTime)value;

            if(inputDate <=today)
            {
                return true;
            }
            return false;
        }
    }
}
