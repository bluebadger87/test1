using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33.Title
{
    public partial class Title : Form
    {
        public Title()
        {
            InitializeComponent();
        }

        //타이틀바에 버전을 표시
        private void Title_Load(object sender, EventArgs e)
        {
            Version oVersion = Assembly.GetEntryAssembly().GetName().Version;
            this.Text = string.Format("{0} Ver.{1}.{2} / Build Time ({3})", "Title 사용하기", 
                                        oVersion.Major, oVersion.Minor, GetBuildDataTime(oVersion));
        }

        //어셈블리 버전 정보로 현재날짜와 시간 가져옴
        public DateTime GetBuildDataTime(Version oVersion)
        {
            string strVerstion = oVersion.ToString();

            // 날짜 등록
            int iDays = Convert.ToInt32(strVerstion.Split('.')[2]); //버전 3번째 항목 7095
            DateTime refData = new DateTime(2000, 1, 1); //2000년1월1일에 + 버전 3번재 항목 더하면
            DateTime dtBuildDate = refData.AddDays(iDays); //오늘날짜 찍힘 {2019-06-05 수 오전 12:00:00}

            // 초 등록
            int iSeconds = Convert.ToInt32(strVerstion.Split('.')[3]); 
            iSeconds = iSeconds * 2; //
            dtBuildDate = dtBuildDate.AddSeconds(iSeconds); //오늘날짜 시간까지 제대로 찍힘 {2019-06-05 수 오후 10:21:48}

            // 시차 조정(이거 잘 안쓸듯,,?)
            DaylightTime daylighttime = TimeZone.CurrentTimeZone.GetDaylightChanges(dtBuildDate.Year);
            if (TimeZone.IsDaylightSavingTime(dtBuildDate, daylighttime))
                dtBuildDate = dtBuildDate.Add(daylighttime.Delta);

            return dtBuildDate; //{2019-06-05 수 오후 10:21:48}
        }










        // Dictionary 함수 예제
        Dictionary<string, Stack<CSize>> oDic = new Dictionary<string, Stack<CSize>>();

        private void btnSizeCheck_Click(object sender, EventArgs e)
        {
            fControlSizeRead();
            fControlSizeWrite();
        }

        //컨트롤 정보를 읽어와서 저장해놓음
        private void fControlSizeRead()
        {
            oDic.Clear();

            // Button 등록
            Stack<CSize> sButton = new Stack<CSize>();
            foreach (var item in gboxControl.Controls)
            {
                if (item is Button)
                {
                    Button obtn = item as Button;

                    CSize oSize = new CSize();
                    oSize.Name = obtn.Name;
                    oSize.Width = obtn.Width;
                    oSize.Height = obtn.Height;
                    sButton.Push(oSize); //stack이니까 push임
                }
            }
            oDic.Add("BUTTON", sButton);
        }

        //리스트박스에 정보를 적음
        private void fControlSizeWrite()
        {
            // Dic에서 Button 정보를 가져옴
            Stack<CSize> sButton = oDic["BUTTON"];
            foreach (CSize item in sButton)
            {
                string strResult = string.Format("Control : Button, Name : {0}, Size ({1}, {2})", item.Name, item.Width, item.Height);
                lboxResult.Items.Add(strResult);
            }
        }

    }
}

