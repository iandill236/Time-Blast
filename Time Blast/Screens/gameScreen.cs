﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Time_Blast
{
    public partial class gameScreen : UserControl
    {
        #region declaring variables
        //booleans

        public static Boolean wKeyDown, aKeyDown, sKeyDown, dKeyDown, spaceKeyDown;

        public static int rightBorder = 1200 - heroSize - 30;
        public static int bottomBorder = 950 - heroSize;

        int room = 0;

        int counter = 0;


        //brushes
        SolidBrush heroBrush = new SolidBrush(Color.Red);
        SolidBrush enemyBrush = new SolidBrush(Color.Blue);
        SolidBrush enemyBrush2 = new SolidBrush(Color.Green);
        SolidBrush objectiveBrush = new SolidBrush(Color.Yellow);

        //picture variables
        #region WW hero image variables
        public static Image wildWestHeroRight = Properties.Resources.WWHero;
        public static Image wildWestHeroLeft = Properties.Resources.HeroLeft;
        public static Image wildWestHeroUp = Properties.Resources.HeroUp;
        public static Image wildWestHeroDown = Properties.Resources.HeroDown;
        public static Image wildWestHeroUpRight = Properties.Resources.HeroUpperRight;
        public static Image wildWestHeroUpLeft = Properties.Resources.HeroUpperLeft;
        public static Image wildWestHeroDownLeft = Properties.Resources.HeroLowerLeft;
        public static Image wildWestHeroDownRight = Properties.Resources.HeroLowerRight;

        #endregion
        #region WW bullet image variables
        public static Image wildWestBulletRight = Properties.Resources.BulletRight;
        public static Image wildWestBulletLeft = Properties.Resources.BulletLeft;
        public static Image wildWestBulletUp = Properties.Resources.BulletUp;
        public static Image wildWestBulletDown = Properties.Resources.BulletDown;
        public static Image wildWestBulletUpRight = Properties.Resources.BulletUpperRight__1_;
        public static Image wildWestBulletUpLeft = Properties.Resources.BulletUpperLeft;
        public static Image wildWestBulletDownLeft = Properties.Resources.BulletLowerLeft;
        public static Image wildWestBulletDownRight = Properties.Resources.BulletLowerRight;
        #endregion

        #region Future hero image variables
        public static Image futureHero = Properties.Resources.FutureHero;
        #endregion
        #region pirate hero image variables
        public static Image pirateHero = Properties.Resources.PirtateHero;
        #endregion


        //lists
        //List<Hero> heroList = new List<Hero>();
        List<Enemy> enemyList = new List<Enemy>();
        List<Bullet> bulletList = new List<Bullet>();


        //hero variables / bullet variables

        public static int heroSize = 50;
        int heroSpeed = 7;
        int enemySpeed = 5;

        public static int bulletSpeed = 9;
        public static int bulletSize = 30;

        //health
        int playerHealth = 4;
        int enemyHealth = 3;

        #endregion


        public gameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            Hero hero1 = new Hero(Hero.x, Hero.y, heroSize);

            StartRoom();
        }

        public void StartRoom()
        {
            Enemy enemy1 = new Enemy(Enemy.x, Enemy.y, heroSize);
            Enemy enemy2 = new Enemy(Enemy.x2, Enemy.y2, heroSize);
            enemyList.Add(enemy1);
            enemyList.Add(enemy2);

            Hero.x = 600;
            Hero.y = 100;
            Enemy.x = 300;
            Enemy.y = 600;
            Enemy.x2 = 700;
            Enemy.y2 = 400;
        }



        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Rectangle heroRec = new Rectangle(Hero.x, Hero.y, heroSize, heroSize);
            Rectangle enemyRec = new Rectangle(Enemy.x, Enemy.y, heroSize, heroSize);
            Rectangle enemyRec2 = new Rectangle(Enemy.x2, Enemy.y2, heroSize, heroSize);
            Rectangle objectiveRec = new Rectangle(600, 600, 20, 20);

            Hero.Move(heroSpeed, wKeyDown, sKeyDown, aKeyDown, dKeyDown);
            counter++;
            if (heroRec.IntersectsWith(enemyRec) || heroRec.IntersectsWith(enemyRec2))
            {

                if (counter > 50)
                {
                    playerHealth--;
                    healthLabel.Text = $"{playerHealth}";
                    counter = 0;
                }
            }
            if (playerHealth == 0)
            {
                gameTimer.Stop();
                lossLabel.Visible = true;
            }

            if (enemyList.Count == 0)
            {
                Rectangle arrowRec = new Rectangle(900, 500, 30, 30);
                Rectangle arrowRec2 = new Rectangle(100, 500, 30, 30);
                Rectangle arrowRec3 = new Rectangle(550, 100, 30, 30);
                Rectangle arrowRec4 = new Rectangle(550, 900, 30, 30);


                if (heroRec.IntersectsWith(arrowRec) && enemyList.Count == 0)
                {
                    if (room == 0)
                    {
                        //set new room and reset character position
                        room = 1;
                        Hero.x = 600;
                        Hero.y = 100;

                        //spawns new enemies
                        Enemy enemy1 = new Enemy(Enemy.x, Enemy.y, heroSize);
                        Enemy enemy2 = new Enemy(Enemy.x2, Enemy.y2, heroSize);
                        enemyList.Add(enemy1);
                        enemyList.Add(enemy2);
                        Enemy.x = 400;
                        Enemy.y = 800;
                        Enemy.x2 = 200;
                        Enemy.y2 = 700;
                    }
                    else if (room == 1)
                    {
                        //set new room and reset character position
                        room = 2;
                        Hero.x = 600;
                        Hero.y = 100;

                        //spawns new enemies
                        Enemy enemy1 = new Enemy(Enemy.x, Enemy.y, heroSize);
                        Enemy enemy2 = new Enemy(Enemy.x2, Enemy.y2, heroSize);
                        Enemy enemy3 = new Enemy(Enemy.x3, Enemy.y3, heroSize);
                        enemyList.Add(enemy1);
                        enemyList.Add(enemy2);
                        enemyList.Add(enemy3);
                        Enemy.x = 200;
                        Enemy.y = 400;
                        Enemy.x2 = 900;
                        Enemy.y2 = 700;
                        Enemy.x3 = 500;
                        Enemy.y3 = 600;
                    }
                    else if (room == 2)
                    {
                        //set new room and reset character position
                        room = 3;
                        Hero.x = 600;
                        Hero.y = 100;

                        //spawns new enemies
                        Enemy enemy1 = new Enemy(Enemy.x, Enemy.y, heroSize);
                        Enemy enemy2 = new Enemy(Enemy.x2, Enemy.y2, heroSize);
                        enemyList.Add(enemy1);
                        enemyList.Add(enemy2);
                        Enemy.x = 300;
                        Enemy.y = 500;
                        Enemy.x2 = 800;
                        Enemy.y2 = 600;
                    }
                }

                if (heroRec.IntersectsWith(arrowRec2) && enemyList.Count == 0 && room < 0)
                {
                    if (room == 1)
                    {


                        //set new room and reset character position
                        room = 0;
                        Hero.x = 850;
                        Hero.y = 500;
                    }
                    if (room == 2)
                    {


                        //set new room and reset character position
                        room = 1;
                        Hero.x = 850;
                        Hero.y = 500;
                    }
                    if (room == 3)
                    {


                        //set new room and reset character position
                        room = 2;
                        Hero.x = 850;
                        Hero.y = 500;
                    }
                }

                if (heroRec.IntersectsWith(arrowRec3) && enemyList.Count == 0 && room == 2)
                {
                    room = 4;
                    //set new room and reset character position
                    room = 3;
                    Hero.x = 600;
                    Hero.y = 100;
                    Enemy enemy1 = new Enemy(Enemy.x, Enemy.y, heroSize);
                    Enemy enemy2 = new Enemy(Enemy.x2, Enemy.y2, heroSize);
                    enemyList.Add(enemy1);
                    enemyList.Add(enemy2);
                    Enemy.x = 600;
                    Enemy.y = 600;
                    Enemy.x2 = 700;
                    Enemy.y2 = 600;
                }

                if (heroRec.IntersectsWith(arrowRec4) && enemyList.Count == 0 && room == 4)
                {
                    room = 2;
                    //set new room and reset character position
                    room = 3;
                    Hero.x = 600;
                    Hero.y = 100;
                }
            }
        
            if (heroRec.IntersectsWith(objectiveRec) && enemyList.Count == 0)
            {
                gameTimer.Stop();
                winLabel.Visible = true;
            }


            if (spaceKeyDown == true)
            {
                if (Form1.wildWestMode == true)
                {
                    Bullet bullet1 = new Bullet(Bullet.bulletX, Bullet.bulletY, bulletSize);
                    bulletList.Add(bullet1);
                    Bullet.WildWestShoot(bulletSpeed);

                    
                }
                //else if (Form1.futureMode == true)
                //{
                //    Bullet.FutureShoot();
                //}
                //else if (Form1.pirateMode == true)
                //{
                //    Bullet.PirateShoot();
                //}
            }
            if (Bullet.bulletMoveUp == true)
            { Bullet.bulletY = Bullet.bulletY - bulletSpeed; }
            else if (Bullet.bulletMoveUp == false)
            { Bullet.bulletY = Bullet.bulletY + bulletSpeed; }
            else if (Bullet.bulletMoveRight == true)
            { Bullet.bulletX = Bullet.bulletX + bulletSpeed; }
            else if (Bullet.bulletMoveRight == false)
            { Bullet.bulletX = Bullet.bulletX - bulletSpeed; }

            Refresh();

        }


        private void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
            }
        }
        private void gameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
            }
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        { 
            //if player health is zero they still move to rub it in your face that they win and have free will and you dont
           Enemy.enemyMove(enemySpeed);

            Refresh();
        }

        private void gameScreen_Paint(object sender, PaintEventArgs e)
        {
           

            //Draws Hero Character
            if (Form1.wildWestMode == true)
            {
                e.Graphics.DrawImage(Hero.heroImage, Hero.x, Hero.y, heroSize, heroSize);
            }

            if (Form1.futureMode == true)
            {
                e.Graphics.DrawImage(futureHero, Hero.x, Hero.y, heroSize, heroSize);
            }
            if (Form1.pirateMode == true)
            {
                e.Graphics.DrawImage(pirateHero, Hero.x, Hero.y, heroSize, heroSize + 10);
            }

            foreach (Bullet b in bulletList)
            {
                e.Graphics.DrawImage(Bullet.bulletImage, Bullet.bulletX, Bullet.bulletY, bulletSize, bulletSize);
            }

            // changing background
            //if (Form1.wildWestMode == true)
            //{
            //    BackgroundImage = Properties.Resources.DesertBackground;
            //}
            //else if (Form1.futureMode == true)
            //{
            //    BackgroundImage = Properties.Resources.SpaceBackground;
            //}
            //else if (Form1.pirateMode == true)
            //{
            //    BackgroundImage = Properties.Resources.OceanBackground;
            //}

            //Draws Enemy Characters
            e.Graphics.FillRectangle(enemyBrush, Enemy.x, Enemy.y, 20, 20);
            e.Graphics.FillRectangle(enemyBrush2, Enemy.x2,Enemy.y2, 20, 20);
            e.Graphics.FillRectangle(enemyBrush, Enemy.x3, Enemy.y3, 20, 20);


            //Draws Objective
            e.Graphics.FillRectangle(objectiveBrush, 600, 600, 20, 20);


            //fills next room arrow
            e.Graphics.FillRectangle(objectiveBrush, 900, 500, 30, 30);

            if (room < 0)
            {
                //fills back room arrow
                e.Graphics.FillRectangle(objectiveBrush, 100, 500, 30, 30);
            }
            if (room == 2)
            {
                //fills back room arrow
                e.Graphics.FillRectangle(objectiveBrush, 550, 100, 30, 30);
            }
            if (room == 4)
            {
                //fills back room arrow
                e.Graphics.FillRectangle(objectiveBrush, 550, 900, 30, 30);
            }
        }

    }
}
