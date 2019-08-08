using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28_Exception
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // FormatException
                int iCheck = 0;
                if (int.TryParse(textBox1.Text, out iCheck))
                {
                    //int.Parse(textBox1.Text);
                }
                else
                {
                    label1.Text = "Data Form이 맞지 않습니다.";
                }


                // ArgumentException
                string strTest = string.Empty;
                List<string> LStringCheck = new List<string>();

                LStringCheck.Add("TEST1");

                //for (int i = 0; i < 2; i++)
                //{
                //    strTest = LStringCheck[i];
                //}

                foreach (string ostrText in LStringCheck)
                {
                    strTest = ostrText;
                }
                
                // NullReferenceException

                List<object> LObject = null;

                if (LObject != null)
                {
                    object oRet = LObject[0];
                }


                // InvalidCastException

                object oCheck = "fgdfg";
                if (oCheck is int)
                {
                    int iCastCheck = (int)oCheck;
                }


            }
            catch (FormatException ex)
            {
                label1.Text = ex.ToString();
            }
            catch (ArgumentException ex)
            {
                label1.Text = ex.ToString();
            }
            catch (NullReferenceException ex)
            {
                label1.Text = ex.ToString();
            }
            catch (InvalidCastException ex)
            {
                label1.Text = ex.ToString();
            }
            catch (Exception ex)
            {
                label1.Text = ex.ToString();
            }
            

            finally
            {
                //label1.Text = "함수를 완료하기 전 실행";
            }
        }
    }
}
