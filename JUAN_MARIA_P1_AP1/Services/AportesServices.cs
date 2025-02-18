using System.Linq.Expressions;
using JUAN_MARIA_P1_AP1.Components.DAL;
using JUAN_MARIA_P1_AP1.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace JUAN_MARIA_P1_AP1.Services;

public class AportesServices(IDbContextFactory<Contexto> DbFactory)
{
    private Aportes Aporte;

    // MÉTODO GUARDAR
    public async Task<bool> Guardar(Aportes aporte)
    {
        if (!await Existe(aporte.AporteId))
        {
            return await Insertar(aporte);
        }
        else
        {
            return await Modificar(aporte);
        }
    }

    // MÉTODO EXISTE
    private async Task<bool> Existe(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .AnyAsync(t => t.AporteId == aporteId);
    }

    // MÉTODO INSERTAR
    private async Task<bool> Insertar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Aportes.Add(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }
    // MÉTODO MODIFICAR
    private async Task<bool> Modificar(Aportes aportes)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(aportes);
        return await contexto.SaveChangesAsync() > 0;
    }

    // MÉTODO BUSCAR
    public async Task<Aportes?> Buscar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .FirstOrDefaultAsync(t => t.AporteId == aporteId);
    }
    // MÉTODO ELIMINAR
    public async Task<bool> Eliminar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .AsNoTracking()
            .Where(t => t.AporteId == aporteId)
            .ExecuteDeleteAsync() > 0;
    }

    // MÉTODO LISTAR
    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

