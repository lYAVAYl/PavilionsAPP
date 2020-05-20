using PavilionsAPP;
using PavilionsDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavilionsAPP.Model
{
    public static class FurnitureCommands
    {
        public static object TryAutorize(string login="", string password="")
        {
            object res = null;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                try
                {
                    using (var context = new PavilionsEntities())
                    {
                        var user = context.Planctons.FirstOrDefault(x => x.Login == login);

                        if (user == null || user.Password != password)
                            res = "Неверный логин или пароль";
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }
            else res = "Ничего не введено";

            return res;
        }

    }
}
