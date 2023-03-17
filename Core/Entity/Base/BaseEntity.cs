namespace Core.Entity.Base;

public abstract class BaseEntity
{
    public long Id { get; set; }
    
    public string Guid = System.Guid.NewGuid().ToString();
}