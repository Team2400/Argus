using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.src
{
    internal class SystemUsageDAO
    {
        private LiteDatabase db;
        private ILiteCollection<SystemUsageDTO> collection;

        // 생성자로 db 파일이름과 table 이름을 받아 초기화 한다.
        public SystemUsageDAO(string fileName, string tableName)
        {
            try
            {
                db = new LiteDatabase(@fileName);
                collection = db.GetCollection<SystemUsageDTO>("SystemUsage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        // 인자로 SystemUsage 3개를 받고 현재 시간과 함께 data삽입
        public void insertDB(double cUsage, double mUsage, double dUsage) 
        {
            SystemUsageDTO data = new SystemUsageDTO { Timestamp = DateTime.Now, CPU = cUsage, Memory = mUsage, Disk = dUsage };
            collection.Insert(data);
        }

        /*
         * limit는 가장 최근 data부터 얼만큼 값을 불러올 지에 대한 값이며,
         * IEnumerable은 iter가 사용 가능한 자료구조로 만약 각 attribute에 대한 값을 불러오려면 무조건 foreach를 사용하여 접근해야한다. 
         * ex)
         * var data = selectSysUsage(5); 최근 data로부터 5개 값을 
         * foreach (var i in data) 
         *     textBox1.Text +=( "CPU: " + i.CPU.ToString()); 
         * 이런식으로 i.CPU로 접근 한 후 원하는 대로 변환하여 사용하면 된다.
         */
        public IEnumerable<SystemUsageDTO> selectSysUsage(int limit)
        {
            return collection.Find(Query.All("Timestamp", Query.Descending), 0, limit);
        }

        public ILiteCollection<SystemUsageDTO> GetCollection()
        {
            return collection;
        }
    }
}
