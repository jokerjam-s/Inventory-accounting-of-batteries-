using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BattaryState.Models
{
    public class AppDBContext: IdentityDbContext<AppUser, AppRoles, int>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):
            base(options)
        {

        }


        public DbSet<TerminalInfo> TerminalInfo { get; set; }

        public DbSet<BatteryInfo> BatteryInfo { get; set; }

        public DbSet<BatteryState> BatteryState { get; set; }

        public DbSet<LastBatteryState> LastBatteryState { get; set; }

        public DbSet<Sklad> Sklad { get; set; }

        public DbSet<OpSystem> OpSystem { get; set; }

        public DbSet<ModelTSD> ModelTSD { get; set; }

    }
}
