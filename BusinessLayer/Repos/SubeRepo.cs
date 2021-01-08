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
       public class SubeRepo : BaseRepo<Sube>, ISubeRepo
{
    public SubeRepo()
    {

    }

    public SubeRepo(DBContext context) : base(context)
    {
    }

    public override Task<List<Sube>> GetAll()
    {
        return _table.AsQueryable().Include(x => x.BilgisayarBaglantilari).ToListAsync();
    }
    public List<Sube> GetFirmaSube(int firmaId)
    {
        return _table.Where(x => x.FirmaId == firmaId).ToList();
    }
}
}
