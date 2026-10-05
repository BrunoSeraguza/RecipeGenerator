using System.Diagnostics.CodeAnalysis;

namespace MyRecipeBookGenerator.Domain.Extensions;

public static class StringExtension
{
    public static bool IsNotEmpty([NotNullWhen(false)]this string? value) => !string.IsNullOrWhiteSpace(value);
    public static bool IsEmpty([NotNullWhen(true)]this string? value) => string.IsNullOrWhiteSpace(value);    
}
