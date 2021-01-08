using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IFirmaRepo:IEntityRepo<Firma>
    {
        
    }
    public interface ISubeRepo : IEntityRepo<Sube>
    {
        public List<Sube> GetFirmaSube(int firmaId);
    }

    public interface IYetkiliRepo : IEntityRepo<Yetkili>
    {
        public List<Yetkili> GetFirmaYetkili(int firmaId);
        public List<Yetkili> GetSubeYetkili(int subeId);
    }

    public interface IBilgisayarBaglantiRepo : IEntityRepo<BilgisayarBaglanti>
    {
        public List<BilgisayarBaglanti> GetFirmaPC_Connection(int firmaId);
    

        public List<BilgisayarBaglanti> GetSubePC_Connection(int subeId);
    
    }

    public interface IProgramRepo : IEntityRepo<Program>
    {
       
    }
    public interface IRemote_CredRepo : IEntityRepo<RemoteCred>
    {

    }

    public interface IUrunRepo : IEntityRepo<Urun>
    {

    }
    public interface IVergiDairesi : IEntityRepo<VergiDairesi>
    {

    }
    
    public interface IRefreshTokenRepo : IEntityRepo<RefreshToken>
    {

    }
    

    public interface IKullaniciRepo : IEntityRepo<Kullanici>
    {
        Task<Kullanici> FindByName(string username);
        Task<bool> CheckPassword(string username, string password);
    }
}
