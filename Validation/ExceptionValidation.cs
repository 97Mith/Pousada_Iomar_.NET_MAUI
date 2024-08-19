using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IomarPousada.Validation;

public class ExceptionValidation : Exception
{
    public ExceptionValidation(string error) : base(error) { }

    public static bool When(bool hasError)
    {
        bool isValid = true;
        if (hasError)
        {
            isValid = false;
        }
        return isValid;
    }

    public static bool IsEmptyOrBlank(string field)
    {
        return When(!string.IsNullOrEmpty(field) || !string.IsNullOrWhiteSpace(field));
    }
    public static bool IsValidLengthSize(string field, int min, int max)
    {
        if (!string.IsNullOrEmpty(field))
        {
            return field.Length < min || field.Length > max;
        }
        return false;
    }
}
