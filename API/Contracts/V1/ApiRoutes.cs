using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version ;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";
        }

        public static class Kullanicilar
        {
            public const string GetAll = Base + "/kullanici/getall"; 
            public const string Get = Base + "/kullanici/{id}"; 
            public const string Update = Base + "/kullanici/update"; 
            public const string Create = Base + "/kullanici/create"; 
            public const string Delete = Base + "/kullanici/delete"; 
            public const string DeleteId = Base + "/kullanici/delete/{id}"; 
            public const string Filter = Base + "/kullanici/filter";
        }

        public static class VergiDaireleri
        {
            public const string GetAll = Base + "/vergiDairesi/getall"; 
        }
        public static class Firmalar
        {
            public const string GetAll = Base + "/firma/getall"; 
            public const string Get = Base + "/firma/{id}"; 
            public const string Update = Base + "/firma/update"; 
            public const string Create = Base + "/firma/create"; 
            public const string Delete = Base + "/firma/delete"; 
            public const string DeleteId = Base + "/firma/delete/{id}"; 
            public const string Filter = Base + "/firma/filter";
        }

        public static class BilgisayarBaglantilari
        {
            public const string GetAll = Base + "/PC_Connection/getall";
            public const string Get = Base + "/PC_Connection/{id}";
            public const string Update = Base + "/PC_Connection/update";
            public const string Create = Base + "/PC_Connection/create";
            public const string Delete = Base + "/PC_Connection/delete";
            public const string DeleteId = Base + "/PC_Connection/delete/{id}";
            public const string Filter = Base + "/PC_Connection/filter";
            public const string GetSubeConnections = Base + "/PC_Connection/getall/{id}";
        }

        public static class Programlar
        {
            public const string GetAll = Base + "/program/getall";
            public const string Get = Base + "/program/{id}";
            public const string Update = Base + "/program/update";
            public const string Create = Base + "/program/create";
            public const string Delete = Base + "/program/delete";
            public const string DeleteId = Base + "/program/delete/{id}";
            public const string Filter = Base + "/program/filter";
        }
        public static class Remote_Creds
        {
            public const string GetAll = Base + "/Remote_Cred/getall";
            public const string Get = Base + "/Remote_Cred/{id}";
            public const string Update = Base + "/Remote_Cred/update";
            public const string Create = Base + "/Remote_Cred/create";
            public const string Delete = Base + "/Remote_Cred/delete";
            public const string DeleteId = Base + "/Remote_Cred/delete/{id}";
            public const string Filter = Base + "/Remote_Cred/filter";
        }
        public static class Subeler
        {
            public const string GetAll = Base + "/Sube/getall";
            public const string Get = Base + "/Sube/{id}";
            public const string GetByFirmaId = Base + "/Sube/getbyfirmaId/{id}";
            public const string Update = Base + "/Sube/update";
            public const string Create = Base + "/Sube/create";
            public const string Delete = Base + "/Sube/delete";
            public const string DeleteId = Base + "/Sube/delete/{id}";
            public const string Filter = Base + "/Sube/filter";
        }

        public static class Urunler
        {
            public const string GetAll = Base + "/Urun/getall";
            public const string Get = Base + "/Urun/{id}";

            public const string Update = Base + "/Urun/update";
            public const string Create = Base + "/Urun/create";
            public const string Delete = Base + "/Urun/delete";
            public const string DeleteId = Base + "/Urun/delete/{id}";
            public const string Filter = Base + "/Urun/filter";
        }

        public static class Yetkililer
        {
            public const string GetAll = Base + "/Yetkili/getall";
            public const string Get = Base + "/Yetkili/{id}";

            public const string Update = Base + "/Yetkili/update";
            public const string Create = Base + "/Yetkili/create";
            public const string Delete = Base + "/Yetkili/delete";
            public const string DeleteId = Base + "/Yetkili/delete/{id}";
            public const string Filter = Base + "/Yetkili/filter";
        }
    }
}
