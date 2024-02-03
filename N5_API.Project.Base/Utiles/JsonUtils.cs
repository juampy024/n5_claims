
using System.Text.Json;

namespace N5_API.Project.Base.Utiles
{
    public class JsonUtils
    {
        private static readonly JsonSerializerOptions optionsSerializeJson = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        /// <summary>
        /// Convierte un Objeto en una cadena JSON (String)
        /// </summary>
        /// <param name="element">Objeto a Serializar</param>
        /// <returns></returns>
        public static string Serialize(object element)
        {
            return JsonSerializer.Serialize(element, optionsSerializeJson);
        }

        /// <summary>
        /// Convierte un JSON en un Objeto
        /// </summary>
        /// <typeparam name="T">Clase</typeparam>
        /// <param name="data">Cadena de texto</param>
        /// <returns></returns>
        public static T Deserialize<T>(string data) where T: class
        { 
            return JsonSerializer.Deserialize<T>(data, optionsSerializeJson);          
        }
    }
}
