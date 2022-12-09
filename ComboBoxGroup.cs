using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace FishingSizes
{
    class CboItem : IDisposable
    {
        public string Text
        {
            get;
            set;
        }

        public Image Image
        {
            get;
            set;
        }

        public CboItem(string text, Image img)
        {
            Text = text;
            Image = img;
        }

        public CboItem(string text)
            : this(text, null)
        {

            // TODO
        }

        public override string ToString()
        {
            return Text;
        }

        public void Dispose()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
    }

    class ComboBoxEx : ComboBox
    {
        public ComboBoxEx()
            : base()
        {

            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= this.Items.Count)
            {
                base.OnDrawItem(e);
                return;
            }

            var item = this.Items[e.Index] as CboItem;

            if (item == null)
            {
                base.OnDrawItem(e);
                return;
            }

            var g = e.Graphics;

            e.DrawBackground();

            if (item.Image != null)
            {
                g.DrawImage(item.Image, e.Bounds.X, e.Bounds.Y, item.Image.Width, e.Bounds.Height);
                g.DrawString(
                    item.Text,
                    e.Font,
                    Brushes.Black,
                    new RectangleF(
                        item.Image.Width + 5,
                        e.Bounds.Y,
                        e.Bounds.Width - item.Image.Width - 5,
                        e.Bounds.Height
                    )
                );
            }
            else
            {
                g.DrawString(
                    item.Text,
                    e.Font,
                    Brushes.Black,
                    new RectangleF(
                        5,
                        e.Bounds.Y,
                        e.Bounds.Width - 5,
                        e.Bounds.Height
                    )
                );
            }

            base.OnDrawItem(e);
        }
    }
}
