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
    public partial class AuthCreate_Control : UserControl
    {
        MethodsDB methodsDB;
        IActivateForm activateForm;

        public AuthCreate_Control(IActivateForm activateForm)
        {
            InitializeComponent();
            lbMessage.Text = "";
            this.activateForm = activateForm;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Parent.FindForm().Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            methodsDB = new MethodsDB(this.Parent.Name, this.Size, tbUserName.Text);
            if (tbPassword.Text == tbConfPassword.Text && tbPassword.Text != "" && tbConfPassword.Text != "")
            {
                if (methodsDB.AddNewUser((tbUserName.Text, tbPassword.Text)))
                {
                    Terminal.ActiveUser = tbUserName.Text;
                    this.Parent.FindForm().Owner.Text += $": {tbUserName.Text}";
                    activateForm.SetActivate(true, tbUserName.Text);

                }
                else lbMessage.Text = "Name creation error";
            }
            else lbMessage.Text = "Password error";
        }
    }
}
