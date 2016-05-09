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
        static Random rng = new Random();
        static Turn currentTurn;
        static DataTable enemyData = EnemyData.GetTable();
        static DataTable skillData = SkillData.GetTable();
        static DataRow[] chosenEnemy;
        static DataRow[] hero;
        static string chooseSkill;
        static int skillChoise;
        static int round;
        static int dmg;
        static int actualPow;

        static int heroHP;
        static int heroMaxHP;
        static int heroMP;
        static int heroMaxMP;
        static Skill[] heroSkills;

        static string enemyName;
        static int enemyHP;
        static int enemyMaxHP;
        static int enemyMP;
        static int enemyMaxMP;
        static Skill[] enemySkills;

        static void Main(string[] args)
        {
            BattleProsessing();
            Console.ReadKey();
        }

        static void BattleProsessing()
        {
            BattleStart(Enemy.IMP);	//Choose the enemy here.
            do
            {
                if (currentTurn == Turn.PLAYER)
                    PlayerTurn();
                else
                    EnemyTurn();
            }
            while (enemyHP > 0 || heroHP > 0);        //Battle processing will happen normally if neither the player nor the enemy has died.
        }

        static void BattleStart(Enemy enemy)
        {
            chosenEnemy = enemyData.Select("ID = " + (int)enemy);       //The Enemy enum must be cast into an int because enums are processed as integers.
            hero = enemyData.Select("ID = " + (int)Enemy.HERO);         //If you don't cast it into an integer, the whole code will explode.

            heroMaxHP = hero[0].Field<int>(2);                  //We do need current HP stored outside the DataTables, but here are also some other commonly printed stats.
            heroHP = heroMaxHP;                                 //Just so we don't need to use the horrible DataRow[] syntax to call them all the time.
            heroMaxMP = hero[0].Field<int>(3);
            heroMP = heroMaxMP;
            heroSkills = hero[0].Field<Skill[]>(10);

            enemyName = chosenEnemy[0].Field<string>(1);
            enemyMaxHP = chosenEnemy[0].Field<int>(2);
            enemyHP = enemyMaxHP;
            enemyMaxMP = chosenEnemy[0].Field<int>(3);
            enemyMP = enemyMaxMP;
            enemySkills = chosenEnemy[0].Field<Skill[]>(10);

            round++;

            int whoStarts = rng.Next(1, 4);		//For now, 1 in 3 chance of enemy ambush.
            if (whoStarts < 3)
            {
                currentTurn = Turn.PLAYER;
                Console.WriteLine(enemyName + " draws near!");
            }
            else
            {
                currentTurn = Turn.ENEMY;
                Console.WriteLine(enemyName + " struck from behind! It's an ambush!");
            }

            Console.ReadKey();
        }

        static void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine("ROUND " + round + "\n\n");
            Console.WriteLine(enemyName + ":   " + enemyHP + " / " + enemyMaxHP + " HP   " + enemyMP + " / " + enemyMaxMP + " MP\n\n");
            Console.WriteLine("You:   " + heroHP + " / " + heroMaxHP + " HP   " + heroMP + " / " + heroMaxMP + " MP\n\n\n\n");


            for (int i = 0; i < heroSkills.Length; i++)     //Let's print the player's skills. This for loop prints the name and the description of the skill int point i.
                Console.WriteLine(i + " - " + skillData.Rows[(int)heroSkills[i]].Field<string>(1) + " - " + skillData.Rows[(int)heroSkills[i]].Field<string>(2)); //Looks ugly, doesn't it?

            Console.WriteLine("\nWhat will you do?\n-- Type the correct skill's number and press Enter --");
            chooseSkill = Console.ReadLine();
            if (int.TryParse(chooseSkill, out skillChoise))
            {
                Console.Clear();
                if (skillChoise < heroSkills.Length && skillChoise >= 0)        //The number should be between 0 and the amount of skills the player has.
                {
                    Console.WriteLine("You used " + skillData.Rows[(int)heroSkills[skillChoise]].Field<string>(1) + " on " + enemyName + "!\n\n");
                    Console.ReadKey();

                    if (skillData.Rows[(int)heroSkills[skillChoise]].Field<SkillType>(4) == SkillType.STR)
                        actualPow = hero[0].Field<int>(4);
                    else
                        actualPow = hero[0].Field<int>(5);
                    dmg = DamageAlgorithm(actualPow, hero[0].Field<int>(6), chosenEnemy[0].Field<int>(6));

                    Console.WriteLine(enemyName + " took " + dmg + " points of damage!");
                    enemyHP -= dmg;
                    if (enemyHP <= 0)
                        Console.WriteLine("It was fatal! " + enemyName + " is no more.");

                    currentTurn = Turn.ENEMY;
                }
                else
                    Console.WriteLine("You don't have a skill with that number.\nMaybe next time you could read the instructions, n00b.");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ha ha, real funny. Try typing an actual integer next time, smartass.");
                Console.ReadLine();
            }
        }

        static void EnemyTurn()
        {
            Console.Clear();

            round++;

            int ai = rng.Next(0, enemySkills.Length);

            if (skillData.Rows[(int)enemySkills[ai]].Field<SkillType>(4) == SkillType.STR)
                actualPow = chosenEnemy[0].Field<int>(4);
            else
                actualPow = chosenEnemy[0].Field<int>(5);
            dmg = DamageAlgorithm(actualPow, chosenEnemy[0].Field<int>(6), hero[0].Field<int>(6));

            Console.WriteLine(enemyName + " used " + skillData.Rows[(int)enemySkills[ai]].Field<string>(1) + " on you! Oh snap!\n\n");
            Console.ReadKey();
            Console.WriteLine("You took " + dmg + " points of damage!");
            heroHP -= dmg;
            if (heroHP <= 0)
                Console.WriteLine("It was fatal! You are no more.");

            currentTurn = Turn.PLAYER;
            Console.ReadKey();
        }

        static int DamageAlgorithm(int pow, int atk, int def)   //pow = Strength/Magic; atk = The particular skill's attack power; def = Defence
        {
            float finalDmg;

            float fRng = (float)rng.Next(90, 111) / 100f;   //Random.Next can't be used for generating float values so let's do things weirdly instead.
            finalDmg = 5 * (float)Math.Sqrt( (pow*3) / def * atk ) * fRng;

            return (int)finalDmg;
        }
    }
}

