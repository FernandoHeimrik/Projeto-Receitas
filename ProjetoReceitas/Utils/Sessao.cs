using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Utils
{
    public class Sessao
    {
        private static string itemReceitaId = "ITEMRECEITA_ID";
        private static string usuario = "USUARIO";

        public static string RetornarItemReceitaId()
        {
            if (HttpContext.Current.Session[itemReceitaId] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[itemReceitaId] = guid.ToString();
            }
            return HttpContext.Current.Session[itemReceitaId].ToString();
        }

        public static string Login(string login)
        {
            HttpContext.Current.Session[usuario] = login;
            return HttpContext.Current.Session[usuario].ToString();
        }
        public static string RetornarUsuario()
        {
            if (HttpContext.Current.Session[usuario] == null)
            {
                return null;
            }
            return HttpContext.Current.Session[usuario].ToString();
        }

        public static void ZerarSessao()
        {
            HttpContext.Current.Session[itemReceitaId] = null;
        }
    }
}
