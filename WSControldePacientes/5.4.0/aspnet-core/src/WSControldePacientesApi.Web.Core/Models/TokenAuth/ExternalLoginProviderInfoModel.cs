using Abp.AutoMapper;
using WSControldePacientesApi.Authentication.External;

namespace WSControldePacientesApi.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
