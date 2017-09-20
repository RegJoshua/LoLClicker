using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Media;

namespace LoLClicker
{
    public partial class mainMenuForm : Form
    {
        SoundPlayer audio = new SoundPlayer();
        Random rand = new Random();
        private int song;

        public mainMenuForm()
        {
            InitializeComponent();
            lolPictureBox.Image = Properties.Resources.LoL;
            playAudio();  
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            stopAudio(audio);
            this.Hide();
            GameForm gf = new GameForm();
            gf.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (songLabel.Left < this.Width)
            {
                songLabel.Left = songLabel.Left + 5;
            }
            else
            {
                songLabel.Left = 0;
            }
        }

        private void mainMenuForm_Load(object sender, EventArgs e)
        {
            timer1.Start();     
        }

        private void playAudio()
        {           
            song = rand.Next(1, 4);
            audio = setAudio(audio, song);
            audio.Play();    
        }

        private void stopAudio(SoundPlayer audio)
        {
            audio.Stop();
        }

        private SoundPlayer setAudio(SoundPlayer sound, int num)
        { 
            if(num == 1)
            {
                sound = new SoundPlayer(Properties.Resources.Zedd___Ignite);
                songLabel.Text = "Now Playing: (Zedd - Ignite)";
                mainPictureBox.Image = Properties.Resources.zeddignite;

            }
            else if(num == 2)
            {
                sound = new SoundPlayer(Properties.Resources.Riot___Sad_Mummy);
                songLabel.Text = "Now Playing: (Riot - Sad Mummy)";
            }
            else if(num == 3)
            {
                sound = new SoundPlayer(Properties.Resources.Riot___Burning_Bright);
                songLabel.Text = "Now Playing: (Riot - Burning Bright)";
                mainPictureBox.Image = Properties.Resources.starguardian;
            }
            return sound;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LoL Clicker is a mouse button click driven game. Click on 'Play Game' will send you to"
                + " the rift where you will defeat every monster in League of Legends. Clicking on the monster will"
                + " deal damage based on your damage. Clicking on an item will allow you to purchase the item. Hover"
                + " over each item for additional information.", "Help");
        }

        private void mainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
