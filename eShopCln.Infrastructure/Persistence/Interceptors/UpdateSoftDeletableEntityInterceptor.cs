using eShopCln.Domain.Common.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace eShopCln.Infrastructure.Persistence.Interceptors;

public sealed class UpdateSoftDeletableEntityInterceptor : SaveChangesInterceptor
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
            .Entries<IAuditableEntity>();

        foreach (var entry in auditableEntries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(e => e.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(e => e.LastModifiedOnUtc).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
