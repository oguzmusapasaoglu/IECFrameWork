
using IFW.Configrations;

using Microsoft.EntityFrameworkCore;

namespace FW.DbManager
{
    public class PostgreContex : DbContext
    {
        public PostgreContex()
        {
        }

        public PostgreContex(DbContextOptions<PostgreContex> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationHelper.GetIFWAppConfiguration().PostgreConnString);
            }
        }
    }
}
