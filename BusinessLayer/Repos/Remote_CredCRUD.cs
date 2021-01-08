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
    public class Remote_CredRepo : BaseRepo<RemoteCred>, IRemote_CredRepo
    {
        public Remote_CredRepo()
        {

        }

        public Remote_CredRepo(DBContext context) : base(context)
        {
        }
    }
}
