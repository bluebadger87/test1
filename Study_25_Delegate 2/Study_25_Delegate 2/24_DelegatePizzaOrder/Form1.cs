using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24_DelegatePizzaOrder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //delegate가 중요한 이유는 이벤트 호출때문이다.
        public delegate int delFuncDow_Edge(int i);
        public delegate int delFuncTopping(string strOrder, int Ea);

        public delegate T delFunc<T>(T i); // 함수명 뒤에 <일반화 변수명 - 형식 매개 변수> 을 사용할 경우 일반화 함수를 지정 가능
        public delegate object delFuncO(object i); // var, object

        int _iTotalPrice = 0; //총액

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dPizzaOrder = new Dictionary<string, int>();  // Pizza 주문

            delFuncDow_Edge delDow = new delFuncDow_Edge(fDow);
            delFuncDow_Edge delEdge = new delFuncDow_Edge(fEdge);
            delFuncTopping delTopping = null;

            int iDowOrder = 1;  int iEdgeOrder = 1;

            // 1.도우 확인
            if (rdoDow1.Checked)
                dPizzaOrder.Add("오리지널", 1);
            else if (rdoDow2.Checked)
            {
                iDowOrder = 2;
                dPizzaOrder.Add("씬", 1);
            }

            // 2.엣지 확인
            if (rdoEdge1.Checked)
                dPizzaOrder.Add("리치골드", 1);
            else if (rdoEdge2.Checked)
            {
                iEdgeOrder = 2;
                dPizzaOrder.Add("치즈크러스터", 1);
            }

            // Delegate
            fCallBackDelegate(iDowOrder, delDow);
            fCallBackDelegate(iEdgeOrder, delEdge);

            // 3. 토핑 확인
            if (cboxTopping1.Checked)
            {
                delTopping = new delFuncTopping(fTopping1);
                dPizzaOrder.Add("소세지", (int)numEa.Value);
            }
            if (cboxTopping2.Checked)
            {
                delTopping += fTopping2; //delegate체인
                dPizzaOrder.Add("감자", (int)numEa.Value);
            }
            delTopping("토핑", (int)numEa.Value);

            // 결과출력
            flboxOrderRed(string.Format("전체 주문 가격은 {0}원 입니다.", _iTotalPrice));
            frmLoadling(dPizzaOrder); //서브폼 호출
        }

        #region ▼Function
        // 1.도우선택
        private int fDow(int iOrder)
        {
            int iPrice = 10000; string strOrder = string.Empty;

            if (iOrder == 1)
                strOrder = string.Format("도우는 오리지널을 선택 하셨습니다. ({0}원)", iPrice.ToString());
            else
                iPrice = 11000;

            if (iOrder == 2)
                strOrder = string.Format("도우는 씬을 선택 하셨습니다. ({0}원)", iPrice.ToString());

            flboxOrderRed(strOrder); //리스트박스에 담음
            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        // 2.엣지선택
        private int fEdge(int iOrder)
        {
            int iPrice = 1000; string strOrder = string.Empty;

            if (iOrder == 1)
                strOrder = string.Format("엣지는 리치골드를 선택 하셨습니다. ({0}원)", iPrice.ToString());
            else
                iPrice = 2000;

            if (iOrder == 2)
                strOrder = string.Format("엣지는 치즈크러스터를 선택 하셨습니다. ({0}원)", iPrice.ToString());

            flboxOrderRed(strOrder); //리스트박스에 담음
            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        // 한 다리 더 걸쳐서 부르는 delegate 
        public int fCallBackDelegate(int i, delFuncDow_Edge dFunction)
        {
            return dFunction(i);
        }

        // 3.토핑 소세지와 감자
        private int fTopping1(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 500;

            strOrder = string.Format("소세지 {0} {1} 개를 선택 하였습니다. : ({2}원 (1ea 500원)", Order, iEa, iPrice);
            flboxOrderRed(strOrder); //리스트박스에 담음
            return _iTotalPrice = _iTotalPrice + iPrice;
        }
        private int fTopping2(string Order, int iEa)
        {
            string strOrder = string.Empty;
            int iPrice = iEa * 200;

            strOrder = string.Format("감자 {0} {1} 개를 선택 하였습니다. : ({2}원 (1ea 200원)", Order, iEa, iPrice);
            flboxOrderRed(strOrder); //리스트박스에 담음
            return _iTotalPrice = _iTotalPrice + iPrice;
        }

        //리스트박스 담아주는 함수
        private void flboxOrderRed(string strOrder)
        {
            lboxOrder.Items.Add(strOrder); //리스트박스에 담음
        }
        #endregion Function▲

        #region ▼event 예제 
        frmPizza fPizza;
        private void frmLoadling(Dictionary<string, int> dPizzaOrder)
        {
            //이미 서브폼이 있으면 지워버림 
            if (fPizza != null) 
            {
                fPizza.Dispose(); //폼을 없애버림
                fPizza = null; //없어도 되는 코드,,
            }

            //서브폼 새로 만듦
            fPizza = new frmPizza();
            fPizza.eventdelPizzaComplete += FPizza_eventdelPizzaComplete;
            fPizza.Show();
            fPizza.fPizzrCheck(dPizzaOrder); //주문dictionary 같이 넘겨줌
        }

        // 자식 form에 대한 delegate event 함수 호출
        private int FPizza_eventdelPizzaComplete(string strResult, int iTime)
        {
            flboxOrderRed("----------------------------------");
            flboxOrderRed(string.Format("{0} / 걸린 시간 : {1}", strResult, iTime));

            // 결과 값을 자식 form으로 return 해주기 위해 사용, 시간 계산을 해서 5분이 넘어 가면 -1
            if (iTime > 4000)
                return -1;
            else
                return 0;
        }
        #endregion event 예제▲

    }
}
