using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28_Exception_Ex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Dictionary<string, Color> dColor = new Dictionary<string, Color>();  // 색상정보를 담아 둘 Dictionary
        Color oSelectColor = new Color();   // 현재 선택 된 생상 정보를 가지고 있을 변수

        // ColorDialog Event를 불러올 Panel
        private void pColor_MouseClick(object sender, MouseEventArgs e)
        {
            //색상팔레트를 보여줌
            DialogResult dRet = cDialogColor.ShowDialog();

            if (dRet == DialogResult.OK)  //색상 선택 후 ok버튼 눌렀을때
                pColor.BackColor = cDialogColor.Color;

            //색상이름이나 정보를 출력
            lblColorinfo.Text = pColor.BackColor.ToString();
        }


        // trackbar의 값이 변할때 불러오는 Event 색상변경스크롤
        private void tbarAlpha_Scroll(object sender, EventArgs e)
        {
            pColor.BackColor = Color.FromArgb(tbarAlpha.Value, pColor.BackColor); //색상값의 Alpha값 변경
            lblColorinfo.Text = pColor.BackColor.ToString();
        }


        // 저장 Button을 Click 했을 경우 선택 색상을 사전에 저장 한 뒤 사전에 있는 값을 List에 뿌려 줌
        private void btnColorSave_Click(object sender, EventArgs e)
        {
            try
            {
                Color oColor = pColor.BackColor;
                dColor.Add(oColor.ToString(), oColor);
                LBoxRefresh();
            }
            catch (ArgumentException ex) //dictionary에 같은 색상의 정보가 key에 있으면 에러임
            {
                MessageBox.Show(ex.ToString());
            }
        }


        // 삭제 Button을 Click 했을 경우 List에서 선택된 값과 같은 key를 가진 사전에 있는 값을 삭제 한뒤 List를 다시 뿌려 줌
        private void btnColorDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lboxColor.SelectedItem != null && dColor.ContainsKey(lboxColor.SelectedItem.ToString()))
                    dColor.Remove(lboxColor.SelectedItem.ToString());
                else
                    MessageBox.Show("삭제할 Item이 없거나 사전에 키가 없습니다.");

                // List를 다시 화면에 뿌려준다
                LBoxRefresh();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        // dictionary에 있는 값을 리스트박스에 새로 넣어줌
        private void LBoxRefresh()
        {
            try
            {
                lboxColor.Items.Clear();
                foreach (string okey in dColor.Keys)
                {
                    lboxColor.Items.Add(okey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        // ListBox의 선택 값이 변경 되면 변경 된 선택 값의 색상 정보를 oSelectColor 변수에 저장 함
        private void lboxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            oSelectColor = dColor[lboxColor.SelectedItem.ToString()];
        }


        // 그림 판에 있는 Panel 중 선택 된 Panel에 대해서 저장한 색상 정보를 기준으로 다시 그려 줌
        private void Panel_Click(object sender, MouseEventArgs e)
        {
            try
            {
                Panel oPanel = sender as Panel;
                oPanel.BackColor = oSelectColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
