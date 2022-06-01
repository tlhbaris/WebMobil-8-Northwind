using North.Business.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Business.Repositories;

public class OrderRepo : RepositoryBase<Order, int>
{
    public OrderRepo(NorthwindContext context) : base(context)
    {

    }
}