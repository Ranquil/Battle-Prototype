﻿using System;
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

        static void Main(string[] args)
        {
            

            BattleStart(Enemy.DUMMY);	//Choose the enemy here.
            do
            {
                if (currentTurn == Turn.PLAYER)
                    PlayerTurn();
                else
                    Console.ReadLine();
            }
            while (enemyHP >= 0 || heroHP >= 0);        //Battle processing will happen normally if neither the player nor the enemy has died.
        }

        void BattleProsessing(Enemy enemy)
        {

        }

        static void BattleStart(Enemy enemy)
        {
            chosenEnemy = enemyData.Select("ID = " + (int)enemy);       //The Enemy enum must be cast into an int because enums are processed as integers.
            hero = enemyData.Select("ID = " + (int)Enemy.HERO);         //If you don't cast it into an integer, the whole code will explode.

            heroMaxHP = hero[0].Field<int>(2);
            heroHP = heroMaxHP;
            heroMaxMP = hero[0].Field<int>(3);
            heroMP = heroMaxMP;

            enemyName = chosenEnemy[0].Field<string>(1);
            enemyMaxHP = chosenEnemy[0].Field<int>(2);
            enemyHP = enemyMaxHP;
            enemyMaxMP = chosenEnemy[0].Field<int>(3);
            enemyMP = enemyMaxMP;

            int whoStarts = rng.Next(1, 4);		//For now, 1 in 3 chance of enemy ambush.
            if (whoStarts < 3)
            {
                currentTurn = Turn.PLAYER;
                Console.WriteLine(enemyName + " draws near!");
            }
            else
            {
                currentTurn = Turn.PLAYER; //Turn.ENEMY;
                Console.WriteLine(enemyName + " struck from behind! It's an ambush!");
            }

            Console.ReadLine();
        }

        static void PlayerTurn()
        {
            Console.Clear();
            Console.WriteLine(enemyName + ":   " + enemyHP + " / " + enemyMaxHP + " HP   " + enemyMP + " / " + enemyMaxMP + " MP\n\n");
            Console.WriteLine("You:   " + heroHP + " / " + heroMaxHP + " HP   " + heroMP + " / " + heroMaxMP + " MP\n\n\n\n");

            heroSkills = hero[0].Field<Skill[]>(10);

            for (int i = 0; i < heroSkills.Length; i++)
                Console.WriteLine(i + " - " + skillData.Rows[(int)heroSkills[i]].Field<string>(1) + " - " + skillData.Rows[(int)heroSkills[i]].Field<string>(2)); //Looks ugly, doesn't it?

            Console.WriteLine("\nWhat will you do?");
            chooseSkill = Console.ReadLine();
            if (int.TryParse(chooseSkill, out skillChoise))
            {
                Console.Clear();
                Console.WriteLine("ei viddu mage");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ha ha, real funny. Type an actual integer next time, smartass.");
                Console.ReadLine();
            }
        }
    }
}

