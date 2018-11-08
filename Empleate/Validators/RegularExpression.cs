namespace Empleate.Validators
{
    public class RegularExpression
    {
        public const string CellphoneValidation = @"^[6-7]{1}[\d]{7}$";
        public const string ImageValidation = @".+\.(jpg|png|gif)$";
        public const string IntegerValidation = @"^\d+$";
        public const string TelephoneValidation = @"^[0-9 ]+$";
        public const string TextValidation = @"^[a-z\sA-Z]+$";
        public const string NumTextValidation = @"^[a-z\sA-Z0-9]+$";
    }
}
