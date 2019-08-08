using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _36_SortedList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SortedList<DateTime, string> slScheduler = new SortedList<DateTime, string>();
        private void btnScheduler_Click(object sender, EventArgs e)
        {
            // 1. Linked List -> 불특정 값을 리스트 중간에 끼워넣고 싶을 때 사용
            //LinkedList<string> sLinkTest = new LinkedList<string>();
            //for (int i = 0; i < 10; i++)
            //{
            //    sLinkTest.AddLast(i.ToString()); //0~10까지 숫자가 적힘
            //}
            //var findnode = sLinkTest.Find("5"); //5의 위치를 찾음
            //sLinkTest.AddAfter(findnode, "NewValue"); //5의 위치 뒤에 값을 넣음

            // 2.Sorted List
            DateTime dSetDate = mcScheduler.SelectionStart; // 선택한 날짜 가져옴
            if (!slScheduler.ContainsKey(dSetDate)) //같은 Key값이 들어가면 에러가 나기 때문
            {
                slScheduler.Add(dSetDate, tboxScheduler.Text); // dictionary형식으로 넣어줌
                mcScheduler.AddBoldedDate(dSetDate); //날짜의 글이 굵어짐
                mcScheduler.UpdateBoldedDates(); //굵어진 달력을 다시 출력해줌
            }
            lboxScheduler.Items.Clear(); //기존 리스트박스 삭제함
            foreach (KeyValuePair<DateTime, string> oitem in slScheduler)
            {
                lboxScheduler.Items.Add(string.Format("{0} : {1}", oitem.Key.ToString("yyyy-MM-dd"), oitem.Value));
            }
        }

        //달력의 날짜 선택하면 해당 일정이 표시되도록 하는 함수
        private void mcScheduler_DateChanged(object sender, DateRangeEventArgs e) 
        {
            DateTime dSetDate = mcScheduler.SelectionStart;
            if (slScheduler.ContainsKey(dSetDate))
                tboxScheduler.Text = slScheduler[dSetDate];
            else
                tboxScheduler.Text = string.Empty;
        }








        private void lboxScheduler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
