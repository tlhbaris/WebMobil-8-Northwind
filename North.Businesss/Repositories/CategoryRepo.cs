using North.Business.Repositories.Abstracts.EntityFrameworkCore;
using North.Core.Entities;
using North.Data;

namespace North.Business.Repositories;

public class CategoryRepo : RepositoryBase<Category,int>
{
    public CategoryRepo(NorthwindContext context) : base(context)
    {
    }
}
