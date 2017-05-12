using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KisiselBlog.Domain.Entities;
using KisiselBlog.Domain.Interfaces;

namespace KisiselBlog.Services.KategoriService
{
    public class KategoriService : IKategoriService
    {
        private readonly IRepository<Kategori> _kategoriRepository;
        public KategoriService(IRepository<Kategori> kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        public void Add(Kategori model)
        {
            _kategoriRepository.Add(model);
        }

        public Kategori Find(int id)
        {
            return _kategoriRepository.GetById(id);
        }

        public IEnumerable<Kategori> GetAll()
        {
            return _kategoriRepository.GetAll();
        }

        public void Insert(Kategori model)
        {
            _kategoriRepository.Add(model);
        }
    }
}
