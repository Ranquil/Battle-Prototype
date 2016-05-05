using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BattlePrototype
{
	enum Turn
	{
		PLAYER, ENEMY
	};
	
    class Program
    {
		Random rng = new Random();
		Turn currentTurn;
		DataTable enemyData = EnemyData.GetTable();
		DataTable skillData = SkillData.GetTable();
		DataRow chosenEnemy;
		
        static void Main(string[] args)
        {
            BattleStart(Enemy.DUMMY);	//Choose the enemy here.
			
            Console.ReadLine();
        }
		
		void BattleProsessing(Enemy enemy)
		{
			
		}
		
		void BattleStart(Enemy enemy)
		{
			chosenEnemy = enemyData.Select("ID == enemy");
			
            int whoStarts = rng.Next(1, 4);		//For now, 1 in 3 chance of enemy ambush.
			if (rng < 3)
			{
				currentTurn = Turn.PLAYER;
				Console.WriteLine(chosenEnemy["Name"] + " draws near!");
			}
			else
			{
				currentTurn = Turn.ENEMY;
				Console.WriteLine(chosenEnemy["Name" + " struck from behind! It's an ambush!"]);
			}
		}
    }
}

