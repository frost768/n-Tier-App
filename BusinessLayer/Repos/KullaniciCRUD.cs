using BusinessLayer.Interfaces;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.RepoS
{

    public class KullaniciRepo : BaseRepo<Kullanici>, IKullaniciRepo
    {
        public KullaniciRepo()
        {

        }

        public KullaniciRepo(DBContext context) : base(context)
        {
        }

        public async Task<bool> CheckPassword(string username, string password)  
        {
            var found = await FindByName(username);
            return found.Password == password;
        }

        public async Task<Kullanici> FindByName(string username)
        {
            return await _table.SingleOrDefaultAsync(x => x.Username == username);
        }
    }
}
