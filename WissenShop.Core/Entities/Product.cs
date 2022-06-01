using WissenShop.Core.Entities.Abstracts;

namespace WissenShop.Core.Entities;

public class Product : BaseEntity<Guid>
{
    public string Name { get; set; }
    public decimal UnitPrice { get; set; } = 0;
    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}