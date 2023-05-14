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
        int ID = 0;
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
                db = new LiteDatabase(@"ArgusDB.db");
                collection = db.GetCollection<SystemUsage>("SystemUsage");
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
        public void insert_DB(int cUsage, int mUsage, int dUsage)
        {
            var data = new SystemUsage { Id = ID++, Timestamp = DateTime.Now, CPU = cUsage, Memory = mUsage, Disk = dUsage };
            collection.Insert(data);
        }
        public class SystemUsage//DB에 들어갈 Data format
        {
            public int Id { get; set; }
            public int CPU { get; set; }
            public int Memory { get; set; }
            public int Disk { get; set; }
            public DateTime Timestamp { get; set; }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            insert_DB(ID, ID, ID);
        }
        
        private ILiteCollection<SystemUsage> selectSysUsage(int limit)
        {
            var data = collection.Find(Query.All("Id", Query.Descending), 0, limit);
            return (ILiteCollection<SystemUsage>)data;
        }

        private void print_Click(object sender, EventArgs e)
        {
            var data = collection.Find(Query.All("Id", Query.Descending), 0, 10);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
