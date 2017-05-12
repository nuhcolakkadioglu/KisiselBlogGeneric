using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KisiselBlog.Domain.Entities;
using KisiselBlog.Domain.Interfaces;

namespace KisiselBlog.Services.MakaleServices
{
    public class MakaleServices : IMakaleServices
    {

        private readonly IRepository<Makale> _makaleRepository;

        public MakaleServices(IRepository<Makale> makaleRepository)
        {
            _makaleRepository = makaleRepository;
        }

        public void Add(Makale makale)
        {
            _makaleRepository.Add(makale);
        }

        public Makale Find(int id)
        {
            return _makaleRepository.GetById(id);
        }

        public IEnumerable<Makale> GetAll()
        {
            return _makaleRepository.GetAll();
        }

        public IQueryable<Makale> GetAll(System.Linq.Expressions.Expression<Func<Makale, bool>> predicate)
        {
            return _makaleRepository.GetAll(predicate);
        }

        public void Insert(Makale model)
        {
            _makaleRepository.Add(model);
        }
    }
}
