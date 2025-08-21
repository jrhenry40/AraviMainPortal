using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

public class IntConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null!;
        }

        if (int.TryParse(text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out int result))
        {
            return result;
        }

        return null!;
    }
}