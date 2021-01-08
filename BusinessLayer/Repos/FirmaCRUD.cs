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
    public class FirmaRepo : BaseRepo<Firma>, IFirmaRepo
    {
        public FirmaRepo()
        {

        }

        public FirmaRepo(DBContext context) : base(context)
        {
        }

       
    }
}
