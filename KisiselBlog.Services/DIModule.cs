using KisiselBlog.Domain.Entities;
using KisiselBlog.Domain.Interfaces;
using KisiselBlog.Infrasturcture.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KisiselBlog.Services
{
   public class DIModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Makale>>().To<Repository<Makale>>();
            Bind<IRepository<Kategori>>().To<Repository<Kategori>>();
            Bind<IRepository<Etiket>>().To<Repository<Etiket>>();
        }
    }
}
