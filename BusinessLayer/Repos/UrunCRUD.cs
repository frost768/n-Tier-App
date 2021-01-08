using BusinessLayer.Interfaces;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.RepoS
{

    public class UrunRepo : BaseRepo<Urun>, IUrunRepo
    {
        public UrunRepo()
        {

        }

        public UrunRepo(DBContext context) : base(context)
        {
        }
    }
}
