using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _31_Linq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        const string sLEVEL = "LEVEL";
        const string sNAME = "NAME";
        const string sATTRIBUTE = "ATTRIBUTE";
        DataTable dt;

        enum EnumName
        {
            슬라임, 가고일, 골렘, 코볼트, 고블린, 고스트, 언데드, 드래곤, 다크나이트, 오우거
        }

        enum EnumAttribute
        {
            불, 물, 바람, 번개, 어둠, 빛, 땅, 나무
        }
       
        // Form Load Event
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTableCreate();  // Data Table 생성
            EnemyCreate();  // 정보 생성
            ComboBoxCreate(); // ComboBox에 Data 입력
        }

        // DataTable 틀을 생성 (※23강 Data Table 생성 참조)
        private void DataTableCreate()
        {
            dt = new DataTable("Enemy");

            DataColumn colLevel = new DataColumn(sLEVEL, typeof(int));
            DataColumn colName = new DataColumn(sNAME, typeof(string));
            DataColumn colAttribute = new DataColumn(sATTRIBUTE, typeof(string));

            dt.Columns.Add(colLevel);
            dt.Columns.Add(colName);
            dt.Columns.Add(colAttribute);
        }

        // Data Table에 자료를 입력
        private void EnemyCreate()
        {
            Random rd = new Random();
            
            foreach (EnumName oName in Enum.GetValues(typeof(EnumName)))   // ※15강 캡슐화에서 사용
            {
                DataRow dr = dt.NewRow();

                dr[sLEVEL] = rd.Next(1, 11);  // 1 ~ 10 중에서 Random
                dr[sNAME] = oName.ToString();  // 이름을 넣어 줌

                int iEnumLength = Enum.GetValues(typeof(EnumAttribute)).Length;  // Enum 의 개수를 가져옴
                int iAttribute = rd.Next(iEnumLength); //iEnumLength 범위 안에서 숫자 하나 랜덤 가져옴
                dr[sATTRIBUTE] = ((EnumAttribute)iAttribute).ToString(); //enum숫자를 enum문자로 바꿔줌

                dt.Rows.Add(dr);
            }
            dgEnemyTable.DataSource = dt; //만든 테이블을 화면에 보내줌
        }

        // Combox에 EnumAttribute를 입력
        private void ComboBoxCreate()
        {
            foreach (EnumAttribute oAttribute in Enum.GetValues(typeof(EnumAttribute)))
            {
                cboxAttribute.Items.Add(oAttribute);
            }
            cboxAttribute.SelectedIndex = 0;
        }

        // Level, Name, 속성 정렬 Button Click
        private void btnSort_Click(object sender, EventArgs e)
        {
            Button oBtn = sender as Button; //어떤버튼인지 정보를 가져옴
            DataTable dtCopy = dgEnemyTable.DataSource as DataTable;   // DataGridViewe에 있는 Data를 dtCopy에 복사

            IEnumerable<DataRow> vSortTable = null;

            switch (oBtn.Name)
            {
                case "btnLevel":
                    vSortTable = from oRow in dtCopy.AsEnumerable() //linq는 foreach랑 비슷함 foreach(var oRow in 데이터)
                                 orderby oRow.Field<int>(sLEVEL) // 정렬 기준
                                 select oRow;
                    break;
                case "btnName":
                    vSortTable = from oRow in dtCopy.AsEnumerable()
                                 orderby oRow.Field<string>(sNAME) // 정렬 기준
                                 select oRow;
                    break;
                case "btnAttribute":
                    vSortTable = from oRow in dtCopy.AsEnumerable()
                                 orderby oRow.Field<string>(sATTRIBUTE) // 정렬 기준
                                 select oRow;
                    break;
                case "btnFilter":
                    vSortTable = from oRow in dtCopy.AsEnumerable()
                                 where oRow.Field<string>(sATTRIBUTE) == cboxAttribute.Text &&
                                 (oRow.Field<int>(sLEVEL) >= nLevelMin.Value && oRow.Field<int>(sLEVEL) <= nLevelMax.Value)
                                 select oRow;
                    break;
            }
            if (vSortTable.Count() > 0)
                dgEnemyTable.DataSource = dtCopy = vSortTable.CopyToDataTable();
                else
                    MessageBox.Show("검색 조건에 맞는 Data가 없습니다.");
            }

            // Cancel Button Click
            private void btnCancel_Click(object sender, EventArgs e)
            {
                dgEnemyTable.DataSource = dt;
            }
    }
}
