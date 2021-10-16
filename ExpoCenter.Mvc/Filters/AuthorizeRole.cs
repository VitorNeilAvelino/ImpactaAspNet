using ExpoCenter.Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;

namespace ExpoCenter.Mvc.Filters
{
    public class AuthorizeRole : AuthorizeAttribute
    {
        public AuthorizeRole(params PerfilUsuario[] perfis)
        {
            //foreach (var perfil in perfis)
            //{
            //    Roles += perfil + ",";
            //}

            //Roles = Roles.TrimEnd(',');

            Roles = string.Join(',', perfis);
        }
    }
}