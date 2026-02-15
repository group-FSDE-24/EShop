using EShop.Domain.Entities.Abstracts;

namespace EShop.Domain.Entities.Concretes;

public class Order : BaseEntity
{
    public string? OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderNote { get; set; }
    public decimal? Total { get; set; }


    // Customer
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }


}
