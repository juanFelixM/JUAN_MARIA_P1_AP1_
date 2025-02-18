using System.Collections.Generic;
using JUAN_MARIA_P1_AP1.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace JUAN_MARIA_P1_AP1.Components.DAL
{
    public class Contexo
    {
        public record Contexto(DbSet<Aportes> Aportes) : DbContext(Options);
    }
}
