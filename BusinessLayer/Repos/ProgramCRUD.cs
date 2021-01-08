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
        public class ProgramRepo : BaseRepo<Program>, IProgramRepo
{
    public ProgramRepo()
    {

    }

    public ProgramRepo(DBContext context) : base(context)
    {
    }
}
}
