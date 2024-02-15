namespace Entities.Base
{
    public interface IEntitySoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public void Undo()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
