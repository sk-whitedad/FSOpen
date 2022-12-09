using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FishingSizes.DataBase
{
    public class MethodsDB
    {
        private string FormName { get; set; }
        private Size SizeForm { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }
        private User user { get; set; }

        public MethodsDB(string formName, Size size, string userName)
        {
            FormName = formName;
            SizeForm = size;
            UserName = userName;
            using (AppContext db = new())
            {
                db.Database.EnsureCreated();
            }
        }

        //загрузка настроек и ключей из DB по юзеру
        public List<Brocker> LoadDBSettings()
        {
            using AppContext db = new();
            var brockers = db.Brockers.Where(p => p.User!.Name == UserName).ToList();//получаем List<Brocker> 
            return brockers;
        }


        //обновление данных в таблице Brocker
        public void UpdBrockerData(List<Brocker> b)
        {
            using AppContext db = new();
            var brockers = db.Brockers.Where(p => p.User!.Name == UserName);//получаем List<Brocker> 
            for (int i = 0; i < brockers.ToList().Count; i++)
            {
                    brockers.ToList()[i].OpenKey = b[i].OpenKey;
                    brockers.ToList()[i].SecretKey = b[i].SecretKey;
                    brockers.ToList()[i].ActivateUses = b[i].ActivateUses;
                    //db.Brockers.Add(brockers.ToList()[i]);
                    db.SaveChanges();
            }           
        }
        //первое открытие дочерней формы и занесение координат в DB
        public void OpenСhildForm()
        {
            using AppContext db = new();
            var coordform = db.CoordForms.Where(p => p.User!.Name == UserName).FirstOrDefault(s => s.FormName == FormName);//получаем List<CoordForm> и потом выбираем форму по имениформы
            var _user = db.Users.FirstOrDefault(u => u.Name == UserName);
            if (coordform == null)
            {
                CoordinatesForm coordForm = new() { FormName = FormName, Coord_X = 100, Coord_Y = 100, Widht = SizeForm.Width, Hight = SizeForm.Height, User = _user };
                db.CoordForms.Add(coordForm);
                db.SaveChanges();
            }
        }
        //обновление координат окна в DB (при закрытии)
        public void UpdateBD(string username, int x, int y, Size sizeform)
        {
            using AppContext db = new();
            var coordform = db.CoordForms.Where(p => p.User!.Name == username).FirstOrDefault(s => s.FormName == FormName);//получаем List<CoordForm> и потом выбираем форму по имениформы
            if (coordform != null)
            {
                coordform.Coord_X = x;
                coordform.Coord_Y = y;
                coordform.Widht = sizeform.Width;
                coordform.Hight = sizeform.Height;
                db.SaveChanges();
            }
        }
        //считывание из DB координат окна
        public Point SetCoordinatesStart()
        {
            using AppContext db = new();
            var coordform = db.CoordForms.Where(p => p.User!.Name == UserName).FirstOrDefault(s => s.FormName == FormName);//получаем List<CoordForm> и потом выбираем форму по имениформы
            return new Point(coordform.Coord_X, coordform.Coord_Y);
        }
        //считывание из DB размера формы
        public Size SetSizeFormStart(string? nameform)
        {
            CoordinatesForm coordform;
            using AppContext db = new();
            if (nameform == null)
                coordform = db.CoordForms.Where(p => p.User!.Name == UserName).FirstOrDefault(s => s.FormName == FormName);
            else
                coordform = db.CoordForms.Where(p => p.User!.Name == UserName).FirstOrDefault(s => s.FormName == nameform);
            return new Size(coordform.Widht, coordform.Hight);
        }
        //получение объекта User из DB
        public User GetUserObj(string name)
        {
            using AppContext db = new();
            return db.Users.FirstOrDefault(s => s.Name == name);
        }
        //создание нового юзера в DB
        public bool AddNewUser((string, string) np)
        {
            using (AppContext db = new())
            {
                var _user = db.Users.FirstOrDefault(s => s.Name == np.Item1);
                if (_user == null && np.Item1 != "")
                {
                    //добавляем юзера
                    user = new() { Name = np.Item1, Password = np.Item2 };
                    db.Users.Add(user);
                    CoordinatesForm coordFormTerm = new() { FormName = "Terminal", Coord_X = 100, Coord_Y = 100, Widht = SizeForm.Width, Hight = SizeForm.Height, User = user };
                    CoordinatesForm coordFormAuth = new() { FormName = "Autentication", Coord_X = 180, Coord_Y = 150, Widht = SizeForm.Width, Hight = SizeForm.Height, User = user };
                    Brocker brocker1 = new() { Name = "Tinkoff", OpenKey = "", SecretKey = "", ActivateUses = true, User = user };
                    Brocker brocker2 = new() { Name = "Alor", OpenKey = "", SecretKey = "", ActivateUses = true, User = user };
                    Brocker brocker3 = new() { Name = "Alpaca", OpenKey = "", SecretKey = "", ActivateUses = true, User = user };
                    Brocker brocker4 = new() { Name = "IB", OpenKey = "", SecretKey = "", ActivateUses = true, User = user };
                    db.CoordForms.AddRange(coordFormTerm, coordFormAuth);
                    db.Brockers.AddRange(brocker1, brocker2, brocker3, brocker4);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public void MigrationDB()
        {
            using AppContext db = new();
            db.Database.Migrate();
        }
    }
}
