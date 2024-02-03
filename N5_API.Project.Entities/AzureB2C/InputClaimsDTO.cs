
using N5_API.Project.Base.Utiles;

namespace N5_API.Project.Entities.AzureB2C
{
    public class InputClaimsDTO
    {
        public string userName { get; set; }
        public string secretKey { get; set; }
        public string totpCode { get; set; }
        public string timeStepMatched { get; set; }

        public override string ToString()
        {
            return JsonUtils.Serialize(this);
        }

        public static InputClaimsDTO Parse(string JSON)
        {
            return JsonUtils.Deserialize<InputClaimsDTO>(JSON);
        }
    }
}
