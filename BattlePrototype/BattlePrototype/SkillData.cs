using System;
using System.Data;

namespace BattlePrototype
{

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

    enum Skill  //You know the drill.
    {
        ATTACK
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

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("MP Cost", typeof(int));
            table.Columns.Add("Skill Type", typeof(SkillType));
            table.Columns.Add("Element", typeof(Element));
            table.Columns.Add("Skill Power", typeof(int));

            return table;
        }


    }
}
