using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26_Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private enum enumPlayer
        {
            아이린, 슬기, 웬디, 조이, 예리,
        }

        int _locationX = 0;
        int _locationY = 0;
        List<Play> lPlay = new List<Play>();

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 서브폼 위치설정
            _locationX = this.Location.X + this.Size.Width; 
            _locationY = this.Location.Y;

            for (int i = 0; i < numPlayerCount.Value; i++)
            {
                Play pl = new Play(((enumPlayer)i).ToString());
                pl.Location = new Point(_locationX, _locationY + pl.Height * i); //위치설정
                pl.eventdelMessage += Pl_eventdelMessage;

                pl.Show();
                pl.fThreadStart();
                lPlay.Add(pl);
            }
        }

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            foreach (Play oPlayForm in lPlay)
            {
                oPlayForm.ThreadAbort();  //프로그램 종료 시점이라서 강제로 Thread를 해제
            }
        }

        //delegate이벤트
        private int Pl_eventdelMessage(object sender, string strResult)
        {
            if (this.InvokeRequired)   // 요청 한 Thread가 현재 Main Thread 있는 Contorl을 엑세스 할 수 있는지 확인
            {
                this.Invoke(new Action(delegate ()
                {
                    Play oPlayerForm = sender as Play;
                    lboxResult.Items.Add(string.Format("Player : {0}, Text : {1}", oPlayerForm.StrPlayerName, strResult));
                }));
            }
            return 0;
        }


    }
}
