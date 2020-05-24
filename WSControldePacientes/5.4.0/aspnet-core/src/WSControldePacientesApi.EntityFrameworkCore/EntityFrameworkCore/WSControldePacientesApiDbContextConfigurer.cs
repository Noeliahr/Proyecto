using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WSControldePacientesApi.EntityFrameworkCore
{
    public static class WSControldePacientesApiDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WSControldePacientesApiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WSControldePacientesApiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
