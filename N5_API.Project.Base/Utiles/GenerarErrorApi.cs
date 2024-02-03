using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;



namespace N5_API.Project.Base.Utiles
{
    public class GenerarErrorApi
    {
        public GenerarErrorApi()
        { 
        }

        public static ModelStateDictionary ObtenerErrores(Dictionary<string,string> errores)        
        {
            ModelStateDictionary model = new ModelStateDictionary(); 
            foreach (KeyValuePair<string, string> kvp in errores)
            {
                model.AddModelError(kvp.Key, kvp.Value);
            }
            return model;
        }

        public static ModelStateDictionary ObtenerError(string campo, string error)
        {
            ModelStateDictionary model = new ModelStateDictionary();
            model.AddModelError(campo, error);
            return model;
        }

       


    }
}
