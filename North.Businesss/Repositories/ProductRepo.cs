using North.Business.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Business.Repositories;

public class ProductRepo : RepositoryBase<Product,int>
{
    public ProductRepo(NorthwindContext context) : base(context)
    {
    }
}