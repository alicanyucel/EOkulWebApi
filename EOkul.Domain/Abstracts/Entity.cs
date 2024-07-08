
namespace EOkul.Domain.Abstracts;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}