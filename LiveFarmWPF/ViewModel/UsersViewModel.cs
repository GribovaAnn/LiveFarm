using LiveFarmWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveFarmWPF.ViewModel
{
    public class UsersViewModel
    {
        public static bool CheckAuth(string login, string password)
        {
            Core db = new Core();
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) throw new Exception("Поля не заполнены");
            if (db.context.Users.Where(x => x.Login == login).Count() == 0) throw new Exception("Пользователя с данным логином не существует");
            if (db.context.Users.Where(x => x.Login == login && x.Password == password).Count() == 0) throw new Exception("Неверный пароль");
            return true;
        }
        public static bool AddUser(string fname, string sname, string login, string password)
        {
            Core db = new Core();
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(sname)) throw new Exception("Поля не заполнены");
            if (db.context.Users.Where(x => x.Login == login).Count() > 0) throw new Exception("Пользователь с таким логином существует");
            Users newUser = new Users() {
                Login = login,
                Password = password,
                Fname = fname,
                Sname = sname,
                RoleId = 1,
            };
            db.context.Users.Add(newUser);
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Пользователь не добавлен");
        }
    }
}
