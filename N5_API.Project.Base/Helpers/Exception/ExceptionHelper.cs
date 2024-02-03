using System;
using Npgsql;

public class ExceptionHelper
{
    public static string IdentifyException(Exception ex)
    {
        if (ex == null)
        {
            throw new ArgumentNullException(nameof(ex), "Provided exception cannot be null.");
        }

        // Check for NpgsqlException
        if (ex is NpgsqlException npgsqlEx)
        {
            // You can add more detailed handling based on NpgsqlException properties
            return $"NpgsqlException: {npgsqlEx.Message}";
        }
        else if (ex is ArgumentNullException)
        {
            return "Argument Null Exception: " + ex.Message;
        }
        else if (ex is ArgumentOutOfRangeException)
        {
            return "Argument Out Of Range Exception: " + ex.Message;
        }
        // Add more specific exceptions here...

        // If the exception type is not handled above, return a generic message
        return "General Exception: " + ex.Message;
    }
}