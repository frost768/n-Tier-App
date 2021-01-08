using BusinessLayer.Interfaces;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.RepoS
{
      public class YetkiliRepo : BaseRepo<Yetkili>, IYetkiliRepo
{
    public YetkiliRepo()
    {

    }

    public YetkiliRepo(DBContext context) : base(context)
    {
    }
    
   
    public List<Yetkili> GetFirmaYetkili(int firmaId)
    {
        return _table.Where(x => x.FirmaId == firmaId).ToList();
    }

    public List<Yetkili> GetSubeYetkili(int subeId)
    {
        return _table.Where(x => x.SubeId == subeId).ToList();
    }
}
}
