using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRO_SEGURIDAD.Models
{
    public interface ILoginData
    {
        string getRolIdUsuario(string UserId);
        string getIdUsuario(string UserName);
    }
}
