using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Entities.Base;
using System.Threading;

namespace BackendCore.Utils
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {


        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            if (eventData.Context is null) return base.SavingChanges(eventData, result);

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is not { State: EntityState.Deleted, Entity: IEntitySoftDelete delete }) continue;
                entry.State = EntityState.Modified;
                delete.IsDeleted = true;
                delete.DeletedAt = DateTime.Now;
            }

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> 
            SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, 
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null) return 
                    base.SavingChangesAsync(eventData, result, cancellationToken);

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is not { State: EntityState.Deleted, Entity: IEntitySoftDelete delete }) continue;
                entry.State = EntityState.Modified;
                delete.IsDeleted = true;
                delete.DeletedAt = DateTime.Now;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);

        }
    }
}
