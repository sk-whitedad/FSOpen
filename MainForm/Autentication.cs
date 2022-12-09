using FishingSizes.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FishingSizes
{
    public partial class Autentication : Form
    {
        IActivateForm activateForm;
        MethodsDB methodsDB;
        public AuthLogin_Control authLoginControl { get; set; }

        public Autentication(IActivateForm _activateForm)
        {
            activateForm = _activateForm;
            InitializeComponent();
        }

        private void Autentication_Load(object sender, EventArgs e)
        {
            //methodsDB = new MethodsDB(this.Name, this.Size, null);
            //this.Location = methodsDB.SetCoordinatesStart();//считываем координаты из БД и устанавливаем форму по ним
            authLoginControl = new AuthLogin_Control(activateForm);
            Controls.Add(authLoginControl);
        }

    }
}
