using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

public class DecimalConverter : DefaultTypeConverter
{
    public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text) || text.Trim().Equals("#VALUE!", StringComparison.OrdinalIgnoreCase) || text.Trim().Equals("#REF!", StringComparison.OrdinalIgnoreCase))
        {
            return null!;
        }

        var cleanedText = text.Trim()
                              .Replace("$", "")
                              .Replace(" ", "")
                              .Trim();

        if (cleanedText.Equals("-"))
        {
            return null;
        }

        decimal result;
        if (decimal.TryParse(cleanedText, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
        {
            return result;
        }

        var cultureInfo = CultureInfo.GetCultureInfo("es-CO");
        if (decimal.TryParse(cleanedText, NumberStyles.Any, cultureInfo, out result))
        {
            return result;
        }

        throw new CsvHelperException(row.Context, $"No se pudo convertir el valor '{text}' a decimal. Se intentaron los formatos 'es-CO' e 'InvariantCulture'.");
    }
}