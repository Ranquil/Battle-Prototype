using System;
using System.Data;

namespace BattlePrototype
{
    enum Enemy      //List all enemies here.
    {
        DUMMY,
        IMP
    };

    class EnemyData
    {

         public static DataTable GetTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(Enemy));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("HP", typeof(int));
            table.Columns.Add("MP", typeof(int));
            table.Columns.Add("Strength", typeof(int));     //3 str
            table.Columns.Add("Magic", typeof(int));
            table.Columns.Add("Defence", typeof(int));      //5 def
            table.Columns.Add("Accuracy", typeof(int));
            table.Columns.Add("Evasion", typeof(int));      //7 eva
            table.Columns.Add("Luck", typeof(int));
            table.Columns.Add("Skills", typeof(Skill[]));   //Add skills as Skill enums to the array.
            table.Columns.Add("Phys", typeof(ElemResistance));      //If all elemental resistances are normal,
            table.Columns.Add("Fire", typeof(ElemResistance));      //stop the row before Phys column.
            table.Columns.Add("Water", typeof(ElemResistance));
            table.Columns.Add("Air", typeof(ElemResistance));
            table.Columns.Add("Earth", typeof(ElemResistance));

            table.Rows.Add(Enemy.DUMMY, "Dummy", 100, 50, 6, 6, 6, 6, 6, 6, SkillSet(Enemy.DUMMY));
            table.Rows.Add(Enemy.IMP, "Imp", 50, 10, 4, 5, 4, 7, 4, 3);

            return table;
        }

        public static Skill[] SkillSet(Enemy enemy)
        {//Assing the skillset to ski.
            Skill[] ski = null;        //Ski is set as something so it can be returned outside if clauses.


            if (enemy == Enemy.DUMMY)
            {
                ski = new Skill[1];
                ski[0] = Skill.ATTACK;
            }

            return ski;
        }
    }
}
