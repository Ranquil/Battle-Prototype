using System;
using System.Data;

namespace BattlePrototype
{

    enum Skill  //Each skill is listed here as an enum. The order isn't too important because skills can be searched with this type of enum.
    {
        ATTACK,
		HUR,
		VIS,
		HAI,
		MAA,
        IKI,
        PIERCE_ATTACK
    };

    enum Element    //All elements are listed here as an enum.
    {
        MU,         //No element
        PHYS,
        FIRE,
        WATER,
        AIR,
        EARTH,
        LIGHT,
        DARK
    };
    enum ElemResistance //And types of elemental resistance here.
    {
        NORMAL,     //x dmg
        WEAK,       //2x dmg
        STRONG,     //0.5x dmg
        NULL,       //0x dmg
        DRAIN       //-1x dmg, heals instead
    };


    enum SkillType  //MAG uses the magic stat, STR uses the strength stat and HEAL heals.
    {
        MAG, STR, HEAL
    };

    class SkillData
    {
        
        public static DataTable GetTable()
        {
            DataTable table = new DataTable("Skills");

            table.Columns.Add("ID", typeof(Skill));
            table.Columns.Add("Name", typeof(string));          //1 name
            table.Columns.Add("Description", typeof(string));   //2 desc
            table.Columns.Add("MP Cost", typeof(int));          //3 mp
            table.Columns.Add("Skill Type", typeof(SkillType)); //4 type
            table.Columns.Add("Element", typeof(Element));      //5 elem
            table.Columns.Add("Skill Power", typeof(int));      //6 atk
            table.Columns.Add("Ignores Defence", typeof(bool)); //7 ign def

            table.Rows.Add(Skill.ATTACK, "Attack", "Deals some physical damage to the enemy.", 0, SkillType.STR, Element.PHYS, 10, false);
            table.Rows.Add(Skill.HUR, "Hur", "Deals fire damage to the enemy. 3MP", 3, SkillType.MAG, Element.FIRE, 15, false);
            table.Rows.Add(Skill.VIS, "Vis", "Deals water damage to the enemy. 3MP", 3, SkillType.MAG, Element.WATER, 15, false);
            table.Rows.Add(Skill.HAI, "Hai", "Deals air damage to the enemy. 3MP", 3, SkillType.MAG, Element.AIR, 15, false);
            table.Rows.Add(Skill.MAA, "Maa", "Deals earth damage to the enemy. 3MP", 3, SkillType.MAG, Element.EARTH, 15, false);
            table.Rows.Add(Skill.IKI, "Iki", "Restores some of your health. 4MP", 4, SkillType.HEAL, Element.MU, 20, true);
            table.Rows.Add(Skill.PIERCE_ATTACK, "Pierce Attack", "Deals physical damage to the enemy. Ignores defence. 7MP", 7, SkillType.STR, Element.PHYS, 20, true);

            return table;
        }

    }
}
