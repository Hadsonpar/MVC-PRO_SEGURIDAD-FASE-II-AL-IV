using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PRO_SEGURIDAD.Models;
using Dapper;

namespace PRO_SEGURIDAD.Repositorio
{
    public class LoginData : ILoginData
    {
        public string getRolIdUsuario(string UserId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBD"].ToString()))
            {
                var dpara = new DynamicParameters();
                dpara.Add("@PN_ID_USUARIO", UserId);
                return con.Query<string>("SP_GET_DES_ROL_IDUSUARIO", dpara, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public string getIdUsuario(string UserName)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionBD"].ToString()))
            {
                var dpara = new DynamicParameters();
                dpara.Add("@PV_USUARIO", UserName);
                return con.Query<string>("SP_GET_IDUSUARIO", dpara, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}