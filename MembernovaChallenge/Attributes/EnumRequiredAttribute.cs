using System.ComponentModel.DataAnnotations;

namespace MembernovaChallenge.Attributes
{
    public class EnumRequiredAttribute : RequiredAttribute
    {
        public Type EnumType { get; set; }

        public EnumRequiredAttribute(Type enumType)
        {
            EnumType = enumType;
        }

        public override bool IsValid(object? value)
        {
            if (value is not string strValue || string.IsNullOrWhiteSpace(strValue))
            {
                return false;
            }

            return Enum.TryParse(EnumType, strValue, out var enumValue);
        }
    }
}
