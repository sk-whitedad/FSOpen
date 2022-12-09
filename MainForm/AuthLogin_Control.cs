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
    public partial class AuthLogin_Control : UserControl
    {

        MethodsDB methodsDB;
        IActivateForm activateForm;

        public AuthLogin_Control(IActivateForm _activateForm)
        {
            InitializeComponent();
            activateForm = _activateForm; 
            methodsDB = new MethodsDB(this.Name, this.Size, null);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            var user = methodsDB.GetUserObj(tbUserName.Text);
            if (user != null)
            {
                if (user.Name == tbUserName.Text && user.Password == tbPassword.Text)
                {
                    this.Parent.FindForm().Owner.Text += $": {tbUserName.Text}";
                    activateForm.SetActivate(true, user.Name);
                }
            }
            else
            {
                lbError.Visible = true;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Parent.FindForm().Close();
        }

        private void btRegistration_Click(object sender, EventArgs e)
        {
            this.Parent.FindForm().Text = "New user";
            var authCreateControl = new AuthCreate_Control(activateForm);
            this.Parent.Controls.Add(authCreateControl);
            this.Dispose();
        }
    }
}