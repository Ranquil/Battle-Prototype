using System;
using System.Data;

namespace BattlePrototype
{

    enum Skill  //Each skill is listed here as an enum. The order isn't too important because there's this thing called a query.
    {
        ATTACK
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
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(Skill));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("MP Cost", typeof(int));
            table.Columns.Add("Skill Type", typeof(SkillType));
            table.Columns.Add("Element", typeof(Element));
            table.Columns.Add("Skill Power", typeof(int));

            table.Rows.Add(Skill.ATTACK, "Attack", "Your run-of-the-mill physical attack.", 0, SkillType.STR, Element.PHYS);

            return table;
        }


    }
}
