using System.Collections.Generic;

namespace JUAN_MARIA_P1_AP1.Components.DAL
{
    public class Contexo
    {
        public class Contexto : DbContext
        {
            public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }

            public DbSet<Aportes> Aportes { get; set; }

        }

    }
}
