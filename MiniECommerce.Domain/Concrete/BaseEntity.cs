namespace MiniECommerce.Domain.Concrete;

public abstract class BaseEntity 
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
    public bool IsActive { get; set; } = true;
}
