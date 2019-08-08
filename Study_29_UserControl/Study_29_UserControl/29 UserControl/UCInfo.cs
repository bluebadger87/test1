using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29_UserControl
{
    public partial class UCInfo : UserControl
    {
        /// <summary>
        /// UserControl 진입점
        /// </summary>
        public UCInfo()
        {
            InitializeComponent();
        }


        // Control의 부모 쪽으로 전달할 Event Delegate 
        public delegate int delEvent(object Sender, string strText);   // delegate 선언
        public event delEvent eventdelSender; // delegate event 선언


        // Control의 속성값을 정의
        [Category("UserProperty"), Description("Image")]
        public Image UserFace
        {
            get { return this.pboxFace.BackgroundImage; }
            set { this.pboxFace.BackgroundImage = value; }
        }
        [Category("UserProperty"), Description("No")]
        public string UserNo
        {
            get { return this.lblNo.Text; }
            set { this.lblNo.Text = value; }
        }
        [Category("UserProperty"), Description("현상범의 이름")]
        public string UserName
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }
        [Category("UserProperty"), Description("현상범의 금액")]
        public string UserGold
        {
            get { return this.lblGold.Text; }
            set { this.lblGold.Text = value; }
        }


        // UserControl Button Event를 한곳으로 모아 놓은 부분
        private void btn_Click(object sender, EventArgs e)
        {
            string strText = string.Empty;
            Button oBtn = sender as Button;  // object 형태로 되어 있는 sender를 Button 형태로 형변환

            switch (oBtn.Name)
            {
                case "btnReg":
                    this.BackColor = Color.Red;
                    strText = string.Format("{0}은 금액 {1}으로 수배중 입니다.", lblName.Text, lblGold.Text);
                    break;
                case "btnIdle":
                    this.BackColor = Color.Yellow;
                    strText = string.Format("{0}은 수배 중지  상태 입니다.", lblName.Text);
                    break;
                default :
                    this.BackColor = Color.Green;
                    strText = string.Format("{0}은 잡혔습니다.", lblName.Text);
                    break;
            }
            // 부모가 Event를 생성하지 않았을 수 있으므로 생성 했을 경우에만 Delegate를 호출
            if (eventdelSender != null)  
                eventdelSender(this, strText);
        }
    }
}
