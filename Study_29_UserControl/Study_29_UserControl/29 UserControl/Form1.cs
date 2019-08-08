using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29_UserControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Program을 Load 했을 경우에 발생 
        private void Form1_Load(object sender, EventArgs e)
        {
            // pMain Control 안에서 생성한 UserControl을 찾아서 형변환 한 뒤 Event를 생성 함
            foreach (var oControl in pMain.Controls)
            {
                if (oControl is UCInfo)
                {
                    UCInfo oInfo = oControl as UCInfo;
                    oInfo.eventdelSender += OInfo_eventdelSender;
                }
            }
        }

        // UserControl Delegate Event 
        private int OInfo_eventdelSender(object Sender, string strText)
        {
            UCInfo oInfo = Sender as UCInfo;
            lboxList.Items.Add(string.Format("{0}) {1}", oInfo.UserNo, strText));
            return 0;
        }
    }
}
