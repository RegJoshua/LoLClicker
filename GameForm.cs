using LoLClicker.Items;
using LoLClicker.Monsters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//RECONFIGURE MATH
namespace LoLClicker
{
    public partial class GameForm : Form
    {
        //Player
        Player player = new Player();

        //Monsters
        Monster monster = new Monster();
        RangeMinion rm = new RangeMinion();
        MeleeMinion mm = new MeleeMinion();
        CannonMinion cm = new CannonMinion();
        ScuttleCrab s = new ScuttleCrab();
        Raptor r = new Raptor();
        Wolf w = new Wolf();
        Krug k = new Krug();
        Gromp g = new Gromp();
        BlueSentinel bs = new BlueSentinel();
        RedSentinel rs = new RedSentinel();
        CloudDrake cd = new CloudDrake();
        WaterDrake wd = new WaterDrake();
        MountainDrake md = new MountainDrake();
        InfernalDrake id = new InfernalDrake();
        RiftHerald rh = new RiftHerald();
        ElderDrake ed = new ElderDrake();
        Baron b = new Baron();
        Poro p = new Poro();

        //Initial Items
        Longsword ls = new Longsword();
        AncientCoin ac = new AncientCoin();
        Spellthief st = new Spellthief();
        Boots boots = new Boots();
        //Level 6 Items
        Pickaxe pick = new Pickaxe();
        Medallion med = new Medallion();
        FrostQueen fq = new FrostQueen();
        Berserker ber = new Berserker();
        Mobility mob = new Mobility();
        //Level 11 Items
        BFSword bfs = new BFSword();
        Talisman tal = new Talisman();
        FrostFang ff = new FrostFang();

        //List to hold the monsters
        private List<Monster> mList = new List<Monster>();

        private int timer;
        private int currentXP = 0;
        private int XPNeeded;
        private int monsterHP;
        private int playerXP;
        private double passiveXP = 0;

        public GameForm()
        {
            InitializeComponent();
           
            initPictureBoxes();
            setTextBoxes();
            hideComponents();           
            //BackgroundImage = Properties.Resources.rift;
            //BackgroundImageLayout = ImageLayout.Stretch;
            mList.Add(rm);
            mList.Add(mm);
            mList.Add(cm);
            mList.Add(s);
            mList.Add(r);
            mList.Add(w);
            mList.Add(k);
            mList.Add(g);
            mList.Add(bs);
            mList.Add(rs);
            mList.Add(cd);
            mList.Add(wd);
            mList.Add(md);
            mList.Add(id);
            mList.Add(rh);
            mList.Add(ed);
            mList.Add(b);
            mList.Add(p);

            initGame();
            
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gameTimer.Interval = 1000; //1000 = 1s
            gameTimer.Start();
            timer++;
            timeLabel.Text = "Time: " + TimeSpan.FromSeconds(timer).ToString();

            player.Gold = player.Gold + (1 * 1.8) + (boots.Amount*boots.PassiveGold) + (ac.Amount * 5) 
                + (med.Amount * 8) + (tal.Amount * tal.PassiveGold) + (st.Amount * st.PassiveGold) 
                + (fq.Amount * fq.PassiveGold) + (ff.Amount * ff.PassiveGold) + (ber.Amount * ber.PassiveGold) + (mob.Amount * mob.PassiveGold);
            goldLabel.Text = "Gold: " + String.Format("{0:F1}", player.Gold);
            passiveXP = passiveXP + 1 + (boots.Amount * boots.PassiveXP) + (ber.Amount * ber.PassiveXP) + (mob.Amount*mob.PassiveXP);
            player.XP = player.XP + 1 + (boots.Amount*boots.PassiveXP) + (ber.Amount * ber.PassiveXP) + (mob.Amount * mob.PassiveXP);
            setXPBar(player.XP);
            debugLabel.Text = "Passive: " + String.Format("{0:F1}", passiveXP);
        }

        private void setXPBar(double xp)
        {
            
            if(xp >= XPArray(player.Level))
            {
                player.Level++;
                if(player.Level >= 18)
                        player.Level = 18;
                checkComponents(player.Level);
                xpBar.Maximum = XPArray(player.Level);
                xpBar.Minimum = (int)player.XP;
                xpBar.Value = (int)player.XP;
                xpLabel.Text = "XP: " + String.Format("{0:F1}",player.XP) + "/" + XPArray(player.Level);
                setTextBoxes();
                endGame(player.XP);
            }
            else
            {
                xpBar.Value = (int)xp;
                xpLabel.Text = "XP: " + String.Format("{0:F1}",player.XP) + "/" + XPArray(player.Level);
            }
        }

        private void endGame(double xp)
        {
            if(player.XP >= XPArray(18))
            {
                gameTimer.Stop();
                fadeTimer.Stop();
                fadeTimer2.Stop();
                this.Hide();
                Results rs = new Results(player, timer);
                rs.Show();
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            monsterButton.BackgroundImage = Properties.Resources.MageMinion;
            monsterButton.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void monsterButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                player.Clicks++;
                label2.Text = "Clicks: " + player.Clicks;
            }
           
            monsterHP = healthBar.Value;
            playerXP = xpBar.Value;

            XPNeeded = XPArray(player.Level);

            monsterHP -= (player.Damage);
            if (monsterHP <= 0)
            {
                fadeLabel.Location = new Point(140, 182);
                fadeLabel.Text = "+" + mList[player.Level - 1].Gold + "g";
                fadeLabel.ForeColor = Color.Black;
                fadeTimer.Start();

                loadNewMonster(player.Level);
                healthBar.Value = monsterHP;
                healthLabel.Text = monsterHP + "/" + monster.Health;
                player.Gold += mList[player.Level - 1].Gold;

                currentXP += mList[player.Level - 1].XP;
                player.XP = player.XP + mList[player.Level - 1].XP;

                xpGainLabel.Location = new Point(140, 244);
                xpGainLabel.Text = "+" + mList[player.Level - 1].XP + " XP";
                xpGainLabel.ForeColor = Color.Black;
                fadeTimer3.Start();
                if (player.XP >= XPArray(player.Level))
                {
                    lvlLabel.Location = new Point(416, 213);
                    lvlLabel.Text = "+1 level";
                    lvlLabel.ForeColor = Color.Black;
                    fadeTimer2.Start();

                    player.Level += 1;
                    if (player.Level >= 18)
                        player.Level = 18;
                    setTextBoxes();
                    loadNewMonster(player.Level);
                    checkComponents(player.Level);
                    xpBar.Maximum = XPArray(player.Level);
                    xpBar.Minimum = (int)player.XP;
                    xpBar.Value = (int)player.XP;
                    xpLabel.Text = "XP: " + String.Format("{0:F1}",player.XP) + "/" + XPArray(player.Level);
                    endGame(player.XP);
                }
                else
                {
                    xpBar.Value = (int)player.XP;
                    xpLabel.Text = "XP: " + String.Format("{0:F1}",player.XP) + "/" + XPNeeded;
                }
            }
            else
            {
                healthBar.Value = monsterHP;
                healthLabel.Text = monsterHP + "/" + monster.Health;
            }

            goldLabel.Text = "Gold: " + String.Format("{0:F1}", player.Gold);
            label2.Focus(); //remove focus from button
        }

        //used to initialize all picture boxes (used for base items)
        private void initPictureBoxes()
        {
            longPictureBox.Image = Properties.Resources.longsword;
            bootsPictureBox.Image = Properties.Resources.boots;
            acPicturebox.Image = Properties.Resources.AncientCoin;
            spellPictureBox.Image = Properties.Resources.Spellthiefs;                          
        }

        private void setTextBoxes()
        {
            //Player Info
            levelLabel.Text = "Level: " + player.Level;
            damageLabel.Text = "Damage: " + player.Damage.ToString();
            pgLabel.Text = "Passive Gold: " + (1.8 + (ac.Amount * 5) + (med.Amount * 8) + 
                + (tal.Amount*tal.PassiveGold) + (boots.Amount * boots.PassiveGold) + (st.Amount * st.PassiveGold)
                + (fq.Amount*fq.PassiveGold) + (ff.Amount*ff.PassiveGold) + (ber.Amount*ber.PassiveGold) + (mob.Amount*mob.PassiveGold));
            passiveXPLabel.Text = "Passive XP: " + (1 + (boots.Amount * boots.PassiveXP) + (ber.Amount * ber.PassiveXP) 
                + (mob.Amount * mob.PassiveXP));
            //Inventory
            invLSLabel.Text = "Longswords: " + ls.Amount;
            invPLabel.Text = "Pickaxe: " + pick.Amount;
            invBFLabel.Text = "BF Swords: " + bfs.Amount;
            invACLabel.Text = "Ancient Coins: " + ac.Amount;
            invMedLabel.Text = "Medallions: " + med.Amount;
            invTalLabel.Text = "Talismans: " + tal.Amount;
            invBLabel.Text = "Boots: " + boots.Amount;
            invSpellLabel.Text = "Spellthief: " + st.Amount;
            invFFLabel.Text = "Frostfang: " + ff.Amount;
            invFrostQLabel.Text = "Frost Queen: " + fq.Amount;
            invBerLabel.Text = "Berserker: " + ber.Amount;
            invMobLabel.Text = "Mobility: " + mob.Amount;
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private int XPArray(int currentLevel)
        {
            int xp;
            
            int[] xpArray = {0, 150, 380, 675, 980, 1330, 1740, 2310, 2830, 3500, 4240, 5200, 6300, 7700, 9320,
                            11300, 15500, 20400, 26325 };
            xp = xpArray[currentLevel];
            return xp;
        }
     
        private void loadNewMonster(int level)
        {
            nameLabel.Text = "" + mList[level - 1].Name;
            monster.Health = mList[level - 1].Health;
            monsterHP = monster.Health;
            healthBar.Minimum = 0;
            healthBar.Maximum = monster.Health;
            healthBar.Value = monster.Health;
            healthLabel.Text = monsterHP + "/" + monster.Health;
            monsterButton.BackgroundImage = mList[level - 1].Image;
            monsterButton.BackgroundImageLayout = ImageLayout.Stretch;  
        }

        private void checkComponents(int level)
        {     
            if(level >= 6)
            {
                //Labels
                invPLabel.Visible = true;
                invMedLabel.Visible = true;
                invFFLabel.Visible = true;
                invBerLabel.Visible = true;
                invMobLabel.Visible = true;
                //ancient medallion              
                medPictureBox.Visible = true;
                medPictureBox.Image = Properties.Resources.Medallion;
                label4.Visible = true;
                //pickaxe
                axePictureBox.Visible = true;
                axePictureBox.Image = Properties.Resources.Pickaxe;
                label5.Visible = true;
                //Frostfang
                frostFPictureBox.Visible = true;
                frostFPictureBox.Image = Properties.Resources.Frostfang;
                ffLabel.Visible = true;
                //berserker boots
                berPictureBox.Visible = true;
                berPictureBox.Image = Properties.Resources.BerserkerB;
                berLabel.Visible = true;
                //Mobility Boots
                mobPictureBox.Visible = true;
                mobPictureBox.Image = Properties.Resources.MobilityB;
                mobLabel.Visible = true;
                          
            }
            if(level >= 11)
            {
                //Labels
                invBFLabel.Visible = true;
                invTalLabel.Visible = true;
                invFrostQLabel.Visible = true;
                //bf sword              
                bfPictureBox.Visible = true;
                bfPictureBox.Image = Properties.Resources.bf;
                label6.Visible = true;     
                //talisman               
                talPictureBox.Visible = true;
                talPictureBox.Image = Properties.Resources.Talismon;
                label7.Visible = true;
                //frost q
                frostQPictureBox.Visible = true;
                frostQPictureBox.Image = Properties.Resources.FrostQueen;
                frostQLabel.Visible = true;                   
            }
        }

        private void hideComponents()
        {
            //***Level 6****
            //medallion           
            medPictureBox.Visible = false;
            label4.Visible = false;
            //pickaxe           
            axePictureBox.Visible = false;
            label5.Visible = false;
            //Frostfang
            frostFPictureBox.Visible = false;
            ffLabel.Visible = false;
            //berserker
            berPictureBox.Visible = false;
            berLabel.Visible = false;
            //mobility boots
            mobPictureBox.Visible = false;
            mobLabel.Visible = false;
           
            //***Level 11****
            //bf sword           
            bfPictureBox.Visible = false;
            label6.Visible = false;
            //talisman       
            talPictureBox.Visible = false;
            label7.Visible = false;
            //frostQ
            frostQPictureBox.Visible = false;
            frostQLabel.Visible = false;
            
            //inventory
            invPLabel.Visible = false;
            invBFLabel.Visible = false;
            invMedLabel.Visible = false;
            invTalLabel.Visible = false;
            invFrostQLabel.Visible = false;
            invFFLabel.Visible = false;
            invMobLabel.Visible = false;
            invBerLabel.Visible = false;
        }
        
        private void initGame()
        {
            monster.Health = mList[player.Level - 1].Health;
            nameLabel.Text = "" + mList[player.Level - 1].Name;
            healthBar.Minimum = 0;
            healthBar.Maximum = monster.Health;
            xpBar.Minimum = 0;
            xpBar.Maximum = XPArray(player.Level);
            healthBar.Value = monster.Health;
            healthLabel.Text = healthBar.Value + "/" + monster.Health;
            xpLabel.Text = "XP: " + currentXP + "/" + XPArray(player.Level);
            goldLabel.Text = "Gold: " + player.Gold.ToString();
        }

        //********Initial Items available to the player*********
        private void longPictureBox_Click(object sender, EventArgs e)
        {
            if (player.Gold >= ls.Cost)
            {
                player.Gold -= ls.Cost;
                ls.Amount++;
                player.Damage += ls.Damage;
                ls.Cost = ls.Cost + (int)(ls.Cost * .1);
                label1.Text = ls.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a longsword!");
            }
        }

        private void spellPictureBox_Click(object sender, EventArgs e)
        {
            if (player.Gold >= st.Cost)
            {
                player.Gold -= st.Cost;
                st.Amount++;
                player.Damage += st.Damage;
                st.Cost = st.Cost + (int)(st.Cost * .1);
                spellLabel.Text = st.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a Spellthief's Edge!");
            }
        }

        private void bootsPictureBox_Click(object sender, EventArgs e)
        {
            if (player.Gold >= boots.Cost)
            {
                player.Gold -= boots.Cost;
                player.Damage += boots.Damage;
                boots.Amount++;
                boots.Cost = boots.Cost + (int)(boots.Cost * .1);
                bootsLabel.Text = boots.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase boots!");
            }
        }

        private void acPicturebox_Click(object sender, EventArgs e)
        {
            if (player.Gold >= ac.Cost)
            {
                player.Gold -= ac.Cost;
                ac.Amount++;
                ac.Cost = ac.Cost + (int)(ac.Cost * .1);
                label3.Text = ac.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase an Ancient Coin!");
            }
        }

        //*****Items available to the player at level 6*******
        private void axePictureBox_Click(object sender, EventArgs e)
        {
            if (player.Gold >= pick.Cost)
            {
                player.Gold -= pick.Cost;
                pick.Amount++;
                player.Damage += pick.Damage;
                pick.Cost = pick.Cost + (int)(pick.Cost * .1);
                label5.Text = pick.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a pickaxe!");
            }
        }

        private void medPictureBox_Click(object sender, EventArgs e)
        {
            if (player.Gold >= med.Cost)
            {
                player.Gold -= med.Cost;
                med.Amount++;
                med.Cost = med.Cost + (int)(med.Cost * .1);
                label4.Text = med.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a Nomad's Medallion!");
            }
        }

        private void frostQPictureBox_Click(object sender, EventArgs e)
        {
            if(player.Gold >= fq.Cost)
            {
                player.Gold -= fq.Cost;
                player.Damage += fq.Damage;
                fq.Amount++;
                fq.Cost = fq.Cost + (int)(fq.Cost * .1);
                frostQLabel.Text = fq.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a Frost Queen's Claim!");
            }
        }

        private void berPictureBox_Click(object sender, EventArgs e)
        {
            if(player.Gold >= ber.Cost)
            {
                player.Gold -= ber.Cost;
                player.Damage += ber.Damage;
                ber.Amount++;
                ber.Cost = ber.Cost + (int)(ber.Cost * .1);
                berLabel.Text = ber.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase Berserker Boots!");
            }
        }

        private void mobPictureBox_Click(object sender, EventArgs e)
        {
            if(player.Gold >= mob.Cost)
            {
                player.Gold -= mob.Cost;
                mob.Amount++;
                mob.Cost = mob.Cost + (int)(mob.Cost * .1);
                mobLabel.Text = mob.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase Mobility Boots!");
            }
        }

        //******Items available to the player at level 11*******
        private void bfPictureBox_Click(object sender, EventArgs e)
        {
            if(player.Gold >= bfs.Cost)
            {
                player.Gold -= bfs.Cost;
                bfs.Cost = bfs.Cost + (int)(bfs.Cost * .1);
                bfs.Amount++;
                player.Damage += bfs.Damage;
                label6.Text = bfs.Cost + "g";
                setTextBoxes();       
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a BF Sword!");
            }
        }

        private void talPictureBox_Click(object sender, EventArgs e)
        {
            if(player.Gold >= tal.Cost)
            {
                player.Gold -= tal.Cost;
                tal.Amount++;
                tal.Cost = tal.Cost + (int)(tal.Cost * .1);
                label7.Text = tal.Cost + "g";
                setTextBoxes();
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a Talisman of Ascension!");
            }
        }

        private void frostFPictureBox_Click(object sender, EventArgs e)
        {
            if(player.Gold >= ff.Cost)
            {
                player.Gold -= ff.Cost;
                ff.Amount++;
                player.Damage += ff.Damage;
                ff.Cost = ff.Cost + (int)(ff.Cost * .1);
                ffLabel.Text = ff.Cost + "g";
                setTextBoxes();                   
            }
            else
            {
                MessageBox.Show("You do not have enough gold to purchase a Frostfang!");
            }
        }

        //***The two timers below allow the text to fadeaway and move
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            fadeLabel.Visible = true;
            int fadingSpeed = 3;
            fadeLabel.ForeColor = Color.FromArgb(fadeLabel.ForeColor.R + fadingSpeed, fadeLabel.ForeColor.G + fadingSpeed, fadeLabel.ForeColor.B + fadingSpeed);

            fadeLabel.Top = fadeLabel.Top - 1;
            if (fadeLabel.ForeColor.R >= this.BackColor.R)
            {
                fadeTimer.Stop();
                fadeLabel.ForeColor = this.BackColor;
                fadeLabel.Visible = false;
            }
        }

        private void fadeTimer2_Tick(object sender, EventArgs e)
        {
            lvlLabel.Visible = true;
            int fadingSpeed = 3;
            lvlLabel.ForeColor = Color.FromArgb(lvlLabel.ForeColor.R + fadingSpeed, lvlLabel.ForeColor.G + fadingSpeed, lvlLabel.ForeColor.B + fadingSpeed);

            lvlLabel.Top = lvlLabel.Top - 1;
            if (lvlLabel.ForeColor.R >= this.BackColor.R)
            {
                fadeTimer2.Stop();
                lvlLabel.ForeColor = this.BackColor;
                lvlLabel.Visible = false;
            }
            
        }

        private void fadeTimer3_Tick(object sender, EventArgs e)
        {
            xpGainLabel.Visible = true;
            int fadingSpeed = 3;
            xpGainLabel.ForeColor = Color.FromArgb(xpGainLabel.ForeColor.R + fadingSpeed, xpGainLabel.ForeColor.G + fadingSpeed, xpGainLabel.ForeColor.B + fadingSpeed);
            xpGainLabel.Top = xpGainLabel.Top - 1;
            if(xpGainLabel.ForeColor.R >= this.BackColor.R)
            {
                fadeTimer3.Stop();
                xpGainLabel.ForeColor = this.BackColor;
                xpGainLabel.Visible = false;
            }
        }

        //Below is every picture box within the shop and the mouseHover functions that will detail when the user
        //decides to hover the mouse over the picturebox. A tooltip feature.
        private void longPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(longPictureBox, "A longsword will give you +10 damage. Click on the image to purchase.");
        }

        private void acPicturebox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(acPicturebox, "Ancient Coin will give +5 gold per second. Click on image to purchase.");
        }

        private void bootsPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(bootsPictureBox, "Boots will give +3 damage, +2 gold per second, and .8 passive XP. Click on image to purchase.");
        }

        private void axePictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(axePictureBox, "Pickaxe will give +25 damage. Click on image to purchase.");
        }

        private void bfPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(bfPictureBox, "A BF Sword will give +45 damage. Click on image to purchase.");
        }

        private void medPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(medPictureBox, "Nomad's Medallion will give +8 gold per second. Click on image to purchase.");
        }

        private void talPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(talPictureBox, "Talsiman of Ascension will give +12 gold per second. Click on image to purchase.");
        }

        private void spellPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(spellPictureBox, "SpellThief's Edge will give +5 damage and +3 gold per second. Click on image to purchase.");
        }

        private void frostQPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(frostQPictureBox, "Frost Queen's Claim will give +18 damage and +9 gold per second. Click on image to purchase.");
        }

        private void frostFPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(frostFPictureBox, "Frostfang will give +12 damage and +6 gold per second. Click on image to purchase.");
        }

        private void berPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(berPictureBox, "Berserker Boots will give +10 damage, +3 gold per second, and 1.5 XP per second. Click on image to purchase.");
        }

        private void mobPictureBox_MouseHover(object sender, EventArgs e)
        {
            ToolTip myTool = new ToolTip();
            myTool.SetToolTip(mobPictureBox, "Mobility Boots will give +4 gold per second and 2 XP per second. Click on image to purchase.");
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            DialogResult ds = MessageBox.Show("Are you sure you want to exit and go to main menu? This will erase all progress.","Main Menu", MessageBoxButtons.YesNo);
            if(ds == DialogResult.Yes)
            {
                this.Hide();
                mainMenuForm mm = new mainMenuForm();
                mm.Show();
            }
            else
            {
                //do nothing
            }
            
        }
    }
}
