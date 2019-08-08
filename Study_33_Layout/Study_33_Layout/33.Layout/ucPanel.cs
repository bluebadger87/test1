using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33.Layout
{
    public partial class ucPanel : UserControl
    {
        public ucPanel()
        {
            InitializeComponent();
        }
        

        private void ucPanel_SizeChanged(object sender, EventArgs e)
        {
            lblPanel.Text = string.Format("({0},{1})", lblPanel.Width, lblPanel.Height);
        }
    }
}
