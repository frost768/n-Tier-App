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
    public class RefreshTokenRepo : BaseRepo<RefreshToken>, IRefreshTokenRepo
    {
        public RefreshTokenRepo()
        {

        }

        public RefreshTokenRepo(DBContext context) : base(context)
        {
            
        }

    }
}
