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
        public event EventHandler eLabelDoubleClickHandler;

        public ucPanel()
        {
            InitializeComponent();
        }
        

        /// <summary>
        /// Panel Size가 변경될 때 화면에 Size를 보여주기 위함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPanel_SizeChanged(object sender, EventArgs e)
        {
            lblPanel.Text = string.Format("({0},{1})", lblPanel.Width, lblPanel.Height);
        }


        /// <summary>
        /// lblPanel을 DoubleClick 했을 경우 Main으로 Event를 전달
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPanel_DoubleClick(object sender, EventArgs e)
        {
            eLabelDoubleClickHandler(this, e);
        }
    }
}
