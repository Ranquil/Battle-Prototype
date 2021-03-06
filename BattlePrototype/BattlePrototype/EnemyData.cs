﻿using System;
using System.Data;

namespace BattlePrototype
{
    enum Enemy      //List all enemies here.
    {
        DUMMY,
        HERO,
        IMP,
        FAIRY,
        _Length     //This probably won't be needed but it's handy in case you need the count of all the enemies in the game.
    };

    class EnemyData
    {
        

         public static DataTable GetTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(Enemy));
            table.Columns.Add("Name", typeof(string));      //1 name
            table.Columns.Add("HP", typeof(int));           //2 hp
            table.Columns.Add("MP", typeof(int));           //3 mp
            table.Columns.Add("Strength", typeof(int));     //4 str
            table.Columns.Add("Magic", typeof(int));        //5 mag
            table.Columns.Add("Defence", typeof(int));      //6 def
            table.Columns.Add("Accuracy", typeof(int));     //7 acc
            table.Columns.Add("Evasion", typeof(int));      //8 eva
            table.Columns.Add("Luck", typeof(int));         //9 lck
            table.Columns.Add("Skills", typeof(Skill[]));   //10 Add skills as Skill enums to the array.
            table.Columns.Add("Phys", typeof(ElemResistance));      //If all elemental resistances are normal,
            table.Columns.Add("Fire", typeof(ElemResistance));      //stop the row before Phys column.
            table.Columns.Add("Water", typeof(ElemResistance));
            table.Columns.Add("Air", typeof(ElemResistance));
            table.Columns.Add("Earth", typeof(ElemResistance));
            table.Columns.Add("Light", typeof(ElemResistance));
            table.Columns.Add("Dark", typeof(ElemResistance));

            table.Rows.Add(Enemy.DUMMY, "Dummy", 100, 50, 6, 6, 6, 6, 6, 6, SkillSet(Enemy.DUMMY));
            table.Rows.Add(Enemy.HERO, "You", 100, 30, 8, 5, 4, 5, 3, 3, SkillSet(Enemy.HERO));
            table.Rows.Add(Enemy.IMP, "Imp", 50, 10, 4, 5, 4, 7, 4, 3, SkillSet(Enemy.IMP), ElemResistance.NORMAL, ElemResistance.STRONG, ElemResistance.WEAK);
            table.Rows.Add(Enemy.FAIRY, "Fairy", 200, 50, 7, 15, 4, 10, 10, 8, SkillSet(Enemy.FAIRY),
                ElemResistance.NORMAL, ElemResistance.WEAK, ElemResistance.STRONG, ElemResistance.NULL, ElemResistance.NORMAL, ElemResistance.NORMAL, ElemResistance.WEAK);

            return table;
        }

        public static Skill[] SkillSet(Enemy enemy)
        {//Assing the skillset to ski.
            Skill[] ski = null;        //Ski is set as something so it can be returned outside if clauses without an else statement.


            if (enemy == Enemy.HERO)
            {
                ski = new Skill[6];
                ski[0] = Skill.ATTACK;
                ski[1] = Skill.HUR;
                ski[2] = Skill.VIS;
                ski[3] = Skill.HAI;
                ski[4] = Skill.MAA;
                ski[5] = Skill.IKI;
            }

            if (enemy == Enemy.DUMMY)
            {
                ski = new Skill[1];
                ski[0] = Skill.ATTACK;
            }
			
			if (enemy == Enemy.IMP)
			{
				ski = new Skill[2];
				ski[0] = Skill.ATTACK;
				ski[1] = Skill.HUR;
			}
			
            if (enemy == Enemy.FAIRY)
            {
                ski = new Skill[4];
                ski[0] = Skill.ATTACK;
                ski[1] = Skill.HAI;
                ski[2] = Skill.VIS;
                ski[3] = Skill.IKI;
            }

            return ski;
        }
    }
}
