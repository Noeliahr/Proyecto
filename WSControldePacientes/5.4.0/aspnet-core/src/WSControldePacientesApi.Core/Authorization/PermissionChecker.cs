using Abp.Authorization;
using WSControldePacientesApi.Authorization.Roles;
using WSControldePacientesApi.Authorization.Users;

namespace WSControldePacientesApi.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
