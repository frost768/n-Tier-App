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
        public class BilgisayarBaglantiRepo : BaseRepo<BilgisayarBaglanti>, IBilgisayarBaglantiRepo
{
    public BilgisayarBaglantiRepo()
    {

    }

    public BilgisayarBaglantiRepo(DBContext context) : base(context)
    {
    }
    public override Task<List<BilgisayarBaglanti>> GetAll()
    {
        return _table.AsQueryable()
            .Include(x => x.RemoteCreds)
            .Include(x => x.Programs)
            .ToListAsync();
    }
    public List<BilgisayarBaglanti> GetFirmaPC_Connection(int firmaId)
    {
        return _table.Where(x => x.FirmaId == firmaId).ToList();
    }

    public List<BilgisayarBaglanti> GetSubePC_Connection(int subeId)
    {
        return _table.Where(x => x.SubeId == subeId).ToList();
    }
}
}
