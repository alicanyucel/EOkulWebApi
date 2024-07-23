namespace eOkulServer.Domain.Abstracts;
public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
        IsActive = true;
        IsDelete = false;
    }
    public Guid Id { get; set; }

    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}
