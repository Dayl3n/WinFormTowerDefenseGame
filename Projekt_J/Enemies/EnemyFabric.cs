using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Projekt_J.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt_J.Enemies
{
    internal class EnemyFabric
    {
        private int lvl, warriorEnemiesCount,archerEnemiesCount,ghostEnemiesCount,trollEnemiesCount, enemyCount;
        private Form parrentForm;
        private PlayerCastle playerCastle;
        private Random rnd=new Random();
        private List<Enemy> enemies = new List<Enemy>();


        //Enemies Stats
        private int warriorHp; //warrior hp depends on level, increase after level 5 from 50 to 100, thats when image changes
        private int warriorAttackValue = 20;
        private int archerHp = 40;
        private int archerAttackValue = 15;
        private int ghostHp = 40;
        private int ghostAttackValue = 25;
        private int trollHp = 200;
        private int trollAttackValue = 80;

        private int[] groundUnitsSpawnHight = { 334, 539 };//maximum and minimum value on cords that ground units can spawn



        private double warriorChance,archerChance,ghostChance,trollChance;
        public EnemyFabric(Form parrentForm, PlayerCastle playerCastle, int level, int BasicEnemiesCount, int RangeEnemiesCount, int FlyingEnemiesCount, int HugeEnemies)
        {
            enemyCount = BasicEnemiesCount + RangeEnemiesCount + FlyingEnemiesCount + HugeEnemies;
            warriorEnemiesCount = BasicEnemiesCount;
            archerEnemiesCount = RangeEnemiesCount;
            ghostEnemiesCount = FlyingEnemiesCount;
            trollEnemiesCount = HugeEnemies;
            warriorHp = level <= 4 ? 50 : 100;
            lvl = level;
            this.parrentForm = parrentForm;
            this.playerCastle = playerCastle;


            warriorChance = warriorEnemiesCount > 0 ? Math.Round((float)warriorEnemiesCount / enemyCount, 2) * 100 : 0;
            archerChance = archerEnemiesCount > 0 ? Math.Round((float)archerEnemiesCount / enemyCount, 2) * 100 : 0;
            ghostChance = ghostEnemiesCount > 0 ? Math.Round((float)ghostEnemiesCount / enemyCount, 2) * 100 : 0;
            trollChance = trollEnemiesCount > 0 ? Math.Round((float)trollEnemiesCount, 2) * 100 : 0;
        }

        public void ChangeMonsteLvL(int newLvL)
        {
            lvl = newLvL; 
        }

        public List<Enemy> CreateWave()
        {
            int[] firstEnemyCords = { rnd.Next(-200, -100), rnd.Next(334, 539) };
            createWarriorEnemy(firstEnemyCords);
            int nextEnemy;
            for (int i = 1; i < enemyCount-1; i++)
            {
                nextEnemy = rnd.Next(0, 101);
                int[] cords = { enemies[i - 1].HitBox.Left + rnd.Next(-2 * enemies[i - 1].HitBox.Width, -enemies[i - 1].HitBox.Width), rnd.Next(groundUnitsSpawnHight[0], groundUnitsSpawnHight[1])};
                if (nextEnemy <= warriorChance)
                {
                    createWarriorEnemy(cords);
                    
                }
                else if (nextEnemy <= warriorChance+archerChance)
                {
                    createArcherEnemy(cords);
                    
                }
                else if (nextEnemy < ghostChance+archerChance+warriorChance)
                {
                    int[] ghostCords = { rnd.Next(-i * 75 - 200,0), rnd.Next(120, 220) };
                    createGhostEnemy(ghostCords);
                }
                else
                    createTrollEnemy(cords);
                    
            }


            return enemies;
        }

        private void createWarriorEnemy(int[] cords)
        {
            Enemy newEnemy = new WarriorEnemy(parrentForm, playerCastle, warriorHp, warriorAttackValue, cords);
            newEnemy.HitBox.MouseClick += new MouseEventHandler((s, e1) => newEnemy.takeDMG(playerCastle.AttackValue));
            enemies.Add(newEnemy);
            warriorEnemiesCount--;
        }

        private void createArcherEnemy(int[] cords)
        {
            Enemy newEnemy = new ArcherEnemy(parrentForm, playerCastle, archerHp, archerAttackValue, cords);
            newEnemy.HitBox.MouseClick += new MouseEventHandler((s, e1) => newEnemy.takeDMG(playerCastle.AttackValue));
            enemies.Add(newEnemy);
            archerEnemiesCount--;
        }
        private void createGhostEnemy(int[] cords)
        {
            Enemy newEnemy = new GhostEnemy(parrentForm, playerCastle, ghostHp, ghostAttackValue, cords);
            newEnemy.HitBox.MouseClick += new MouseEventHandler((s, e1) => newEnemy.takeDMG(playerCastle.AttackValue));
            enemies.Add(newEnemy );
            ghostEnemiesCount--;
        }
        private void createTrollEnemy(int[] cords)
        {
            Enemy newEnemy = new TrollEnemy(parrentForm, playerCastle, trollHp, trollAttackValue, cords);
            newEnemy.HitBox.MouseClick += new MouseEventHandler((s, e1) => newEnemy.takeDMG(playerCastle.AttackValue));
            enemies.Add(newEnemy);
            trollEnemiesCount--;
        }





    }
}
