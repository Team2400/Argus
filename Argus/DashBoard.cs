using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Argus
{
    public partial class DashBoard : Form
    {
        private static int ID = 0;
        private LiteDatabase db;
        private ILiteCollection<SystemUsage> collection;
        
        public DashBoard()
        {
            InitializeComponent();

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                db = new LiteDatabase(@"ArgusDB.db");//DB file name(DB Ceate)
                collection = db.GetCollection<SystemUsage>("SystemUsage");//table name(Collection Create)
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void test_Click(object sender, EventArgs e)
        {

        }
        public void insert_DB(int cUsage, int mUsage, int dUsage)//인자로 SystemUsage 3개를 받고 현재 시간과 함께 data삽입
        {
            var data = new SystemUsage { Timestamp = DateTime.Now, CPU = cUsage, Memory = mUsage, Disk = dUsage };
            collection.Insert(data);
        }
        public class SystemUsage//DB에 들어갈 Data format
        {
            public int CPU { get; set; }
            public int Memory { get; set; }
            public int Disk { get; set; }
            public DateTime Timestamp { get; set; }
        }
        
        private IEnumerable<SystemUsage> selectSysUsage(int limit)//limit는 가장 최근 data부터 얼만큼 값을 불러올 지에 대한 값
            //IEnumerable은 iter가 사용 가능한 자료구조로 만약 각 attribute에 대한 값을 불러오려면 무조건 foreach를 사용하여 접근해야한다. 이하는 그 예시이다.
            //var data = selectSysUsage(5); 최근 data로부터 5개 값을 불러온다
            //foreach (var i in data) foreach문
            //    textBox1.Text +=( "CPU: " + i.CPU.ToString()); 이런식으로 i.CPU로 접근 한 후 원하는 대로 변환하여 사용하면 된다.
        {
            var data = collection.Find(Query.All("Timestamp", Query.Descending), 0, limit);
            return data;
        }



       

        
    }
}
