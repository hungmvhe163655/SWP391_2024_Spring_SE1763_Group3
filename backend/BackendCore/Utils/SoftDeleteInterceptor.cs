using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Entities.Base;

namespace BackendCore.Utils
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry is not { State: EntityState.Deleted, Entity: IEntitySoftDelete delete }) continue;
                entry.State = EntityState.Modified;
                delete.IsDeleted = true;
                delete.DeletedAt = DateTime.Now;
            }
            return result;
        }
    }
}
