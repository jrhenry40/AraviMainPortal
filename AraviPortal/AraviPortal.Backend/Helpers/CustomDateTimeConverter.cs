using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

public class CustomDateTimeConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null!;
        }

        var formats = new[] { "d-MMM-yy", "M/d/yyyy h:mm:ss tt" };
        DateTime result;

        if (DateTime.TryParseExact(text, formats, CultureInfo.GetCultureInfo("es-ES"), DateTimeStyles.None, out result))
        {
            return result;
        }

        return null!;
    }
}