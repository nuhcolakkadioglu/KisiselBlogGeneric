using KisiselBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KisiselBlog.Services.MakaleServices
{
    public interface IMakaleServices
    {
        void Add(Makale makale);
        IEnumerable<Makale> GetAll();
        Makale Find(int id);
        void Insert(Makale model);
        IQueryable<Makale> GetAll(Expression<Func<Makale, bool>> predicate);
    }
}
