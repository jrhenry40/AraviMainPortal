using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace AraviPortal.Backend.Helpers;

// Este es el conversor personalizado para CsvHelper
public class NullableIntWithDecimalConverter : ITypeConverter
{
    // Este método se llama para convertir el valor de texto del CSV a un tipo de dato de C#
    public object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        // Si el texto está vacío o es nulo, devuelve null (para tipos Nullable)
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        // Intenta convertir directamente a entero. Si no funciona, intenta con decimal.
        if (int.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out int intValue))
        {
            return intValue;
        }
        else if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue))
        {
            // Trunca la parte decimal y convierte a entero
            return (int)decimalValue;
        }

        // Si ninguna conversión es posible, devuelve null para evitar el error.
        return null;
    }

    // Este método es para convertir de C# a texto, lo dejamos como está si no se usa para escritura.
    public string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value == null)
        {
            return string.Empty;
        }
        return value.ToString();
    }
}

// Nuevo conversor personalizado para decimales que maneja errores de conversión.
public class NullableDecimalConverter : ITypeConverter
{
    public object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }

        // Reemplaza la coma por el punto para manejar ambos formatos decimales.
        var cleanedText = text.Replace(',', '.');

        if (decimal.TryParse(cleanedText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue))
        {
            return decimalValue;
        }

        // Si la conversión falla (por ejemplo, el campo contiene texto), retorna null.
        return null;
    }

    public string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
    {
        if (value == null)
        {
            return string.Empty;
        }
        return value.ToString();
    }

    // Nuevo conversor para manejar valores que se esperan como fechas,
    // pero pueden venir con texto o formatos inesperados.
    public class NullableDateTimeConverter : ITypeConverter
    {
        public object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            if (DateTime.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
            {
                return dateValue;
            }
            return null;
        }

        public string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
        {
            return value?.ToString();
        }
    }
}