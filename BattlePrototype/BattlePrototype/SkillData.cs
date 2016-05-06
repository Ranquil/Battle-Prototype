using System;
using System.Data;

namespace BattlePrototype
{

    enum Skill  //Each skill is listed here as an enum. The order isn't too important because there's this thing called a query.
    {
        ATTACK,
		HUR,
		VIS,
		HAI,
		MAA
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
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("MP Cost", typeof(int));
            table.Columns.Add("Skill Type", typeof(SkillType));
            table.Columns.Add("Element", typeof(Element));
            table.Columns.Add("Skill Power", typeof(int));

            table.Rows.Add(Skill.ATTACK, "Attack", "Deals some physical damage to the enemy.", 0, SkillType.STR, Element.PHYS);
            table.Rows.Add(Skill.HUR, "Hur", "Deals fire damage to the enemy. 3MP", 3, SkillType.MAG, Element.FIRE);
            table.Rows.Add(Skill.VIS, "Vis", "Deals water damage to the enemy. 3MP", 3, SkillType.MAG, Element.WATER);
            table.Rows.Add(Skill.HAI, "Hai", "Deals air damage to the enemy. 3MP", 3, SkillType.MAG, Element.AIR);
            table.Rows.Add(Skill.MAA, "Maa", "Deals earth damage to the enemy. 3MP", 3, SkillType.MAG, Element.EARTH);

            return table;
        }


    }
}
