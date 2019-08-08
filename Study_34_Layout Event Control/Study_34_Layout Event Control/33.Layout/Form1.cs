using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33.Layout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // ucCMenu Event 등록
            ucCMenu.eColorAction += UcCMenu_eColorAction;

            // ucPanel Event 등록
            ucPanelTop.eLabelDoubleClickHandler += UcPanel_eLabelDoubleClickHandler;
            ucPanelCenter1.eLabelDoubleClickHandler += UcPanel_eLabelDoubleClickHandler;
            ucPanelCenter2.eLabelDoubleClickHandler += UcPanel_eLabelDoubleClickHandler;
            ucPanelRight.eLabelDoubleClickHandler += UcPanel_eLabelDoubleClickHandler;
        }


        /// <summary>
        /// ucCMenu Event Function
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void UcCMenu_eColorAction(Button arg1, Color arg2)
        {
            //Button obtn = arg1 as Button;

            string strPanelNeme = string.Empty;

            switch (arg1.Name)
            {
                case "btn1":
                    ucPanelTop.BackColor = arg2;
                    strPanelNeme = "Panel Top";
                    break;
                case "btn2":
                    ucPanelCenter1.BackColor = arg2;
                    strPanelNeme = "Panel Center1";
                    break;
                case "btn3":
                    ucPanelCenter2.BackColor = arg2;
                    strPanelNeme = "Panel Center2";
                    break;
                case "btn4":
                    ucPanelRight.BackColor = arg2;
                    strPanelNeme = "Panel Right";
                    break;
                default:
                    break;
            }

            string strResult = string.Format("선택 : {0}, {1}의 색상을 {2}로 변경", arg1.Name, strPanelNeme, arg2.ToString());
            lboxLog.Items.Add(strResult);                
        }

        /// <summary>
        /// ucPanel Event Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcPanel_eLabelDoubleClickHandler(object sender, EventArgs e)
        {
            string strResult = ucCMenu.fButtonColorChange((ucPanel)sender);

            lboxLog.Items.Add(strResult);
        }

    }
}
