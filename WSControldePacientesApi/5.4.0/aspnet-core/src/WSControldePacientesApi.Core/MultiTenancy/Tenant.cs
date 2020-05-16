using Abp.MultiTenancy;
using WSControldePacientesApi.Authorization.Users;

namespace WSControldePacientesApi.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
