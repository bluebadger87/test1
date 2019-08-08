using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30_Lambda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        enum enumProduct
        {
            고기 = 1000,
            과자 = 500,
            야채 = 50000,
            컴퓨터 = 232334
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //리스트박스에 문자 집어넣기
            foreach (enumProduct item in Enum.GetValues(typeof(enumProduct)))
            {
                listBox1.Items.Add(item); //고기, 과자, 야채, 컴퓨터
            }
            listBox1.Items.Add(enumProduct.고기); //고기
            listBox1.Items.Add(enumProduct.야채); //야채
            
            

            //리스트박스에 숫자 집어넣기
            foreach (enumProduct item in Enum.GetValues(typeof(enumProduct)))
            {
                listBox2.Items.Add((int)item); //1000, 500, 50000, 232334
            }
            listBox2.Items.Add((int)enumProduct.고기); //1000
            listBox2.Items.Add((int)enumProduct.야채); //500


            //Enum값에서 숫자로 문자 가져오는 방법
            var aa = ((enumProduct)1000).ToString(); //고기
            var bb = ((enumProduct)500).ToString(); //과자
            var cc = ((enumProduct)1).ToString(); // 1이 들어감
        }

        //enum값 가져오기
        private void btnNext_Click(object sender, EventArgs e)
        {
            var aa = listBox1.SelectedItem.ToString(); //리스트박스 안의 문자를 그대로 가져옴(고기)
            var bb = (int)Enum.Parse(typeof(enumProduct), listBox1.SelectedItem.ToString()); //숫자를 가져옴(1000)

            var cc = listBox2.SelectedItem.ToString(); //리스트박스 안의 문자를 그대로 가져옴(1000)
            var dd = Enum.Parse(typeof(enumProduct), listBox2.SelectedItem.ToString()); //문자를 가져옴(고기)
        }
    }
}
