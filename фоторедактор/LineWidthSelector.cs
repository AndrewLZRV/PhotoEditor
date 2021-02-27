using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace фоторедактор
{
    public partial class LineWidthSelector : Form
    {
        public LineWidthSelector()
        {
            InitializeComponent();
        }

        private byte width = 3;

        public byte WidthFinal
        {
            get
            {
                return this.width;
            }
        }

        private void widthTrack_Scroll(object sender, EventArgs e)
        {
            label1.Text = ("Ширина линии - " + widthTrack.Value);
            width = (byte) widthTrack.Value;
        }
    }
}
