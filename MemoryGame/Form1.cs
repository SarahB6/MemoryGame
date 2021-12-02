using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //ADD TIMER AFTER FLIPPING SECOND CARD OVER

        //Card class - image, flippedOver ? 
        //Player class - how many pairs
        //MemoryGame - 
        //pairs of images that are placed in random locations
        //when a player clicks on an image, it flips over
        //when the player clicks on another image, they are compared. if they match, they stay revealed.
        //otherwise, they are flipped back over
        //once all images are flipped, check who has more pairs. player 1 or player 2. 
        //make a reset function
        PictureBox[] pictureBoxes = new PictureBox[16];
        Bitmap[] cardImages;
        Bitmap[] boardArray = new Bitmap[16];
        Random rand= new Random();
        Image cardBack = Properties.Resources.cardback;
        bool first = true;
        int firstIndex;
        int secondIndex;
        bool firstPlayersTurn = true;
        int firstPlayerScore;
        int secondPlayerScore;

        public void setupBoard ()
        {
            List<int> generatedIndexs = new List<int>();
            for (int i = 0; i<boardArray.Length; i++)
            {
                int imageAtIndex = rand.Next(boardArray.Length);
                while (generatedIndexs.Contains(imageAtIndex))
                {
                    imageAtIndex = rand.Next(boardArray.Length);
                }
                boardArray[i] = cardImages[imageAtIndex];
                generatedIndexs.Add(imageAtIndex);
            }
            secondPlayerScore = 0;
            firstPlayersTurn = true;
            firstPlayerScore = 0;
            player1.Text = "Player 1";
            player2.Text = "Player 2";
            this.Text = "Player 1's Turn";
            for (int i = 0; i < 16; i++)
            {
                pictureBoxes[i].Image = cardBack;
            }
            //Delete This**************************************************************
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cardImages = new Bitmap[]
            {
                Properties.Resources.beef,
                Properties.Resources.beef,
                Properties.Resources.Chicken,
                Properties.Resources.Chicken,
                Properties.Resources.plant,
                Properties.Resources.plant,
                Properties.Resources.poison,
                Properties.Resources.poison,
                Properties.Resources.x,
                Properties.Resources.x,
                Properties.Resources.tnt,
                Properties.Resources.tnt,
                Properties.Resources.dog,
                Properties.Resources.dog,
                Properties.Resources.lizard,
                Properties.Resources.lizard
        };

            int x = 10;
            int y = 20;
            int count = 0;
           

            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    pictureBoxes[count] = new PictureBox();
                    pictureBoxes[count].Location = new Point(x, y);
                    pictureBoxes[count].Size = new Size(70, 100);
                    pictureBoxes[count].Tag = count;
                    pictureBoxes[count].SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxes[count].Image = cardBack;
                    pictureBoxes[count].Click += pictureBoxClick;
                    Controls.Add(pictureBoxes[count]);
                    x += pictureBoxes[count].Size.Width + 5;
                    count++;
                }
                x = 10;
                y += 110;

            }
            setupBoard();
            
        }

        private void pictureBoxClick(object sender, EventArgs e)
        {
            PictureBox selected = (PictureBox)sender;
            int selectedIndex = (int)selected.Tag;
                if (selected.Image == cardBack && flipTimer.Enabled == false)
                {
                    selected.Image = boardArray[selectedIndex];
                    if (first)
                    {
                        firstIndex = selectedIndex;
                        first = false;
                    }
                    else
                    {
                        secondIndex = selectedIndex;
                        pictureBoxes[secondIndex].Image = boardArray[secondIndex];
                        if (checkImage(boardArray[firstIndex], boardArray[secondIndex]))
                        {
                            MessageBox.Show($"pair: {firstIndex} {secondIndex}");
                            if (firstPlayersTurn)
                            {
                                firstPlayerScore++;
                                player1.Text = $"Player 1 \nScore: {firstPlayerScore}";
                            }
                            else
                            {
                                secondPlayerScore++;
                                player2.Text = $"Player 2 \nScore: {secondPlayerScore}";
                        }
                            if (firstPlayerScore + secondPlayerScore == 8)
                            {
                                DialogResult response = MessageBox.Show("Play Again?", "Game Over!", MessageBoxButtons.YesNo);
                                if (response == DialogResult.Yes)
                                {
                                    setupBoard();
                                }
                            }
                        }
                        else
                        {
                            flipTimer.Enabled = true;

                        }

                        first = true;
                    firstPlayersTurn = !firstPlayersTurn;
                    }

                }
                if (firstPlayersTurn)
                {
                    this.Text = "Player 1's turn";
                }
                else
                {
                    this.Text = "Player 2's turn";
                }
        }
        public bool checkImage(Bitmap image1, Bitmap image2)
        {
           for (int i = 0; i < 70; i++)
            {
                if (image1.GetPixel(i, i) != image2.GetPixel(i,i))
                {
                    return false;
                }
            }
            return true;
        }
        private void flipTimer_Tick(object sender, EventArgs e)
        {
            pictureBoxes[firstIndex].Image = cardBack;
            pictureBoxes[secondIndex].Image = cardBack;
            flipTimer.Enabled = false;
        }
    }
}
