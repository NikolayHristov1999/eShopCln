using eShopCln.Domain.Common.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace eShopCln.Infrastructure.Persistence.Interceptors;

public sealed class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;

        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var auditableEntries = dbContext.ChangeTracker
            .Entries<IDeletableEntity>();

        foreach (var entry in auditableEntries)
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.Property(e => e.DeletedOnUtc).CurrentValue = DateTime.UtcNow;
                entry.Property(e => e.IsDeleted).CurrentValue = true;

                entry.State = EntityState.Modified;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
