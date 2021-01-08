using BusinessLayer.Interfaces;
using DataAccess;
using Entities;

namespace BusinessLayer.RepoS
{
    public class VergiDairesiRepo : BaseRepo<VergiDairesi>, IVergiDairesi
    {
        public VergiDairesiRepo()
        {

        }

        public VergiDairesiRepo(DBContext context) : base(context)
        {
        }

       
    }
}