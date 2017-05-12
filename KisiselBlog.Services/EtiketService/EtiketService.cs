using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KisiselBlog.Domain.Entities;
using KisiselBlog.Domain.Interfaces;

namespace KisiselBlog.Services.EtiketService
{
    public class EtiketService : IEtiketService
    {
        private readonly IRepository<Etiket> _etiketService;

        public EtiketService(IRepository<Etiket> etiketService)
        {
            _etiketService = etiketService;
        }

        public void Add(Etiket model)
        {
            _etiketService.Add(model);   
        }

        public Etiket Find(int id)
        {
            return _etiketService.GetById(id);
        }

        public IEnumerable<Etiket> GetAll()
        {
            return _etiketService.GetAll();
        }

        public void Insert(Etiket model)
        {
            _etiketService.Add(model);
        }
    }
}
