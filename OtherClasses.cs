using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FishingSizes
{
    public class BrockerName
    {
        public string[] BName = {"Tinkoff", "Alor", "Alpaca", "IB"};
    }

    public class LS_Trade
    {
        int L { get; set; }
        int S { get; set; }
        int i;
        (int, int) LS_Prc;
        int Coeff { get; set; }

        public LS_Trade(int coeff)
        {
            this.Coeff = coeff;
            L = 10 * this.Coeff;
            S = 10 * this.Coeff;
        }

        public (int, int) LS_Calc(int l, int s)
        {
            L += l;
            S += s;
            LS_Prc.Item1 = 100 * L / (L + S);
            LS_Prc.Item2 = 100 - LS_Prc.Item1;
            //Debug.WriteLine($"{LS_Prc.Item1} / {L} : {LS_Prc.Item2} / {S}");
            if (L >= 100*Coeff || S >= 100 * Coeff)
            {
                L = LS_Prc.Item1 * Coeff;
                S = LS_Prc.Item2 * Coeff;
                //Debug.WriteLine($"Сброс данных: {LS_Prc.Item1} / {L} : {LS_Prc.Item2} / {S}");
            }
            return LS_Prc;
        }
    }

    public class ResetPrintsForm
    {
        int i;
        DataGridView dgv { get; set; }
        private int RowCountSets = 50;

        public ResetPrintsForm(DataGridView dgv)
        {
            this.dgv = dgv;
        }
        public void RstPrints( )
        {
            if (dgv.RowCount >= RowCountSets)
            {
                dgv.Rows.RemoveAt(dgv.RowCount - 1);
                dgv.FirstDisplayedScrollingRowIndex = 0;//устанавливаем координату скролинга

            }
        }
    }

}
