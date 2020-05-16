using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WSControldePacientesApi.Configuration;
using WSControldePacientesApi.Web;

namespace WSControldePacientesApi.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WSControldePacientesApiDbContextFactory : IDesignTimeDbContextFactory<WSControldePacientesApiDbContext>
    {
        public WSControldePacientesApiDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WSControldePacientesApiDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WSControldePacientesApiDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WSControldePacientesApiConsts.ConnectionStringName));

            return new WSControldePacientesApiDbContext(builder.Options);
        }
    }
}
