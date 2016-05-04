using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BattlePrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = EnemyData.GetTable();

            Console.WriteLine(table.Rows[0].Field<string>(0));
            Console.ReadLine();
        }
    }
}

