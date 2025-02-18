using System.Collections.Generic;
using JUAN_MARIA_P1_AP1.Components.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JUAN_MARIA_P1_AP1.Components.DAL
{
    public class Contexto(DbContextOptions<Contexto> Options) : DbContext(Options)
    {
        public DbSet<Aportes> Aportes { get; set; }
    }
}
