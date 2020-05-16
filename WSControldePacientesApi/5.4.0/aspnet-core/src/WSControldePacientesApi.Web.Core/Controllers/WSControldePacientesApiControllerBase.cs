using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace WSControldePacientesApi.Controllers
{
    public abstract class WSControldePacientesApiControllerBase: AbpController
    {
        protected WSControldePacientesApiControllerBase()
        {
            LocalizationSourceName = WSControldePacientesApiConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
