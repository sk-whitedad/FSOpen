using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FishingSizes.DataBase;

namespace FishingSizes
{
    public partial class Settings_Control : UserControl
    {
        private MethodsDB methodsDB;

        public Settings_Control()
        {
            //Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            InitializeComponent();
            if (!cbAlorUses.Checked)
            {
                tbTokenAlor.Enabled = true;
            }
            else
            {
                tbTokenAlor.Enabled = false;
            }
            if (!cbTinkoffUses.Checked)
            {
                tbTokenTinkoff.Enabled = true;
            }
            else
            {
                tbTokenTinkoff.Enabled = false;
            }
            if (!cbAlpacaUses.Checked)
            {
                tbKey.Enabled = true;
                tbSecret.Enabled = true;
            }
            else
            {
                tbKey.Enabled = false;
                tbSecret.Enabled = false;
            }
        }

    private void btnSaveSett_Click(object sender, EventArgs e)
        {
            var formWithSett = this.FindForm() as IHasSettings; // стандартный метод который вернет форму на которой находится контрол
            if (formWithSett != null)
            {
                formWithSett.BrockerSett["Alpaca"].OpenKey = CryptoHelper.Encrypt(tbKey.Text);
                formWithSett.BrockerSett["Alpaca"].SecretKey = CryptoHelper.Encrypt(tbSecret.Text);
                formWithSett.BrockerSett["Tinkoff"].SecretKey = CryptoHelper.Encrypt(tbTokenTinkoff.Text);
                formWithSett.BrockerSett["Alor"].SecretKey = CryptoHelper.Encrypt(tbTokenAlor.Text);
                formWithSett.BrockerSett["Alpaca"].ActivateUses = cbAlpacaUses.Checked;
                formWithSett.BrockerSett["Tinkoff"].ActivateUses = cbTinkoffUses.Checked;
                formWithSett.BrockerSett["Alor"].ActivateUses = cbAlorUses.Checked;
                formWithSett.BrockerSett["IB"].ActivateUses = cbIB.Checked;
                //formWithSett.Sett.SaveSett(formWithSett.Sett);//сохранение настроек в файл settings.json
            }
            BrockerName brockerName = new BrockerName();
            methodsDB = new MethodsDB(this.Name, this.Size, Terminal.UserName);
            List<Brocker> br = new List<Brocker>();
            for (int i = 0; i < brockerName.BName.Length; i++)
            {
                switch (brockerName.BName[i])
                {
                    case "Tinkoff":
                        br.Add(new Brocker() { Name = brockerName.BName[i], OpenKey = "", SecretKey = formWithSett.BrockerSett["Tinkoff"].SecretKey, ActivateUses = formWithSett.BrockerSett["Tinkoff"].ActivateUses });
                        break;
                    case "Alor":
                        br.Add(new Brocker() { Name = brockerName.BName[i], OpenKey = "", SecretKey = formWithSett.BrockerSett["Alor"].SecretKey, ActivateUses = formWithSett.BrockerSett["Alor"].ActivateUses});
                        break;
                    case "Alpaca":
                        br.Add(new Brocker() { Name = brockerName.BName[i], OpenKey = formWithSett.BrockerSett["Alpaca"].OpenKey, SecretKey = formWithSett.BrockerSett["Alpaca"].SecretKey, ActivateUses = formWithSett.BrockerSett["Alpaca"].ActivateUses });
                        break;
                    case "IB":
                        br.Add(new Brocker() { Name = brockerName.BName[i], OpenKey = "", SecretKey = "", ActivateUses = formWithSett.BrockerSett["IB"].ActivateUses });
                        break;
                }
            }
            methodsDB.UpdBrockerData(br);

            this.Visible = false;
            this.Parent.Size = methodsDB.SetSizeFormStart("Terminal");
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbAlpacaUses_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbAlpacaUses.Checked)
            {
                tbKey.Enabled = true;
                tbSecret.Enabled = true;
            }
            else
            {
                tbKey.Enabled = false;
                tbSecret.Enabled = false;
            }
        }

        private void cbAlorUses_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbAlorUses.Checked)
            {
                tbTokenAlor.Enabled = true;
            }
            else
            {
                tbTokenAlor.Enabled = false;
            }
        }

        private void cbTinkoffUses_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbTinkoffUses.Checked)
            {
                tbTokenTinkoff.Enabled = true;
            }
            else
            {
                tbTokenTinkoff.Enabled = false;
            }
        }
    }
}
