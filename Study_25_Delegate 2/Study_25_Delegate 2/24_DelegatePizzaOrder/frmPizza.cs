using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_DelegatePizzaOrder
{
    public partial class frmPizza : Form
    {
        public frmPizza()
        {
            InitializeComponent();
        }

       

        public delegate int delPizzaComplete(string strResult, int iTime);  // delegate 선언
        public event delPizzaComplete eventdelPizzaComplete;  // delegate event 이벤트 선언

        // 닫기버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // pizza 주문 진행 상황을 표시 하기 위한 함수
        internal void fPizzrCheck(Dictionary<string, int> dPizzaOrder)
        {
            int iTotalTime = 0;

            foreach (var item in dPizzaOrder) //여기서 var는 KeyValuePair
            {
                int iNowTime = 0,  iTime = 0,  iCount = item.Value;
                string strType = string.Empty;

                switch (item.Key)
                {
                    // 도우
                    case "오리지널":
                        iNowTime = 3000; strType = "도우"; break;
                    case "씬":
                        iNowTime = 3500; strType = "도우"; break;

                    // 엣지
                    case "리치골드":
                        iNowTime = 500; strType = "엣지"; break;
                    case "치즈크러스터":
                        iNowTime = 400; strType = "엣지"; break;

                    // 토핑
                    case "소세지":
                        iNowTime = 32; strType = "토핑"; break;
                    case "감자":
                        iNowTime = 17; strType = "토핑"; break;
                    default:
                        break;
                }
                //리스트박스에 출력해줌
                iTime = iNowTime * iCount;
                iTotalTime = iTotalTime + iTime;
                lboxMake.Items.Add(string.Format("{0}) {1} : {2}초 ({3}초, {4}개)", strType, item.Key, iTime, iNowTime, iCount));

                Refresh();
                Thread.Sleep(1000);
            }
            int iRet = eventdelPizzaComplete("Pizza가 완성 되었습니다.", iTotalTime);

            if (iRet == 0)
                lboxMake.Items.Add("주문 완료 확인!!");
            else
                lboxMake.Items.Add("제작 시간 초과로 고객 반품!!!");
        }
    }
}
