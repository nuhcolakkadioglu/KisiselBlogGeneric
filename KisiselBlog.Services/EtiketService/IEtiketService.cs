using KisiselBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisiselBlog.Services.EtiketService
{
    public interface IEtiketService
    {
        void Add(Etiket model);
        IEnumerable<Etiket> GetAll();
        Etiket Find(int id);
        void Insert(Etiket model);
    }
}
