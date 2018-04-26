using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalSearchAlgorithmsFormApplication
{
    public partial class Form1 : Form
    {
        bool sizeCheck = false;
        bool algorithmCheck = false;

        int tileSize = 60;
        int gridSize = 4;
        //int algorithmChoice = 0;

        PictureBox[] pictureBoxes = new PictureBox[10];
        Queen[] queens = new Queen[10];//meaning board can be max 10x10
        // Queen q = new Queen();
        public Form1()
        {
            InitializeComponent();
            //comboBox1.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
        }
        // class member array of Panels to track chessboard tiles
        private Panel[,] _chessBoardPanels;
        private void Form1_Load(object sender, EventArgs e)
        {
            createBoard();
            arrayPicture();
        }
        public void createBoard()
        {

            var clr1 = Color.DarkGray;
            var clr2 = Color.White;

            // initialize the "chess board"
            _chessBoardPanels = new Panel[gridSize, gridSize];

            // double for loop to handle all rows and columns
            for (var n = 0; n < gridSize; n++)
            {
                for (var m = 0; m < gridSize; m++)
                {
                    // create new Panel control which will be one 
                    // chess board tile
                    var newPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(25 + tileSize * n, 25 + tileSize * m)
                    };


                    // add to Form's Controls so that they show up
                    Controls.Add(newPanel);

                    // add to our 2d array of panels for future use
                    _chessBoardPanels[n, m] = newPanel;

                    // color the backgrounds
                    if (n % 2 == 0)
                        newPanel.BackColor = m % 2 != 0 ? clr1 : clr2;
                    else
                        newPanel.BackColor = m % 2 != 0 ? clr2 : clr1;
                }
            }
        }
        public void arrayPicture()
        {
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            pictureBoxes[4] = pictureBox5;
            pictureBoxes[5] = pictureBox6;
            pictureBoxes[6] = pictureBox7;
            pictureBoxes[7] = pictureBox8;
            pictureBoxes[8] = pictureBox9;
            pictureBoxes[9] = pictureBox10;
            for (int i = 0; i < 10; i++)
            {
                queens[i] = new Queen();
                queens[i].setX(-1);
                queens[i].setY(-1);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithmCheck = true;
            button1.Enabled = false;
            if (comboBox1.SelectedIndex == 0)
            {
                //1
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                //2
                textBox3.Visible = false;
                label5.Visible = false;
                //3
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                //1
                textBox1.Text = "1000";
                textBox2.Text = "1";
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                //2
                textBox3.Visible = false;
                label5.Visible = false;
                //3
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
            
            else if (comboBox1.SelectedIndex == 2)
            {
                //2
                textBox3.Text = "10";
                textBox3.Visible = true;
                label5.Visible = true;
                //1
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                //3
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
            else if(comboBox1.SelectedIndex == 3)
            {
                //3
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                //1
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                //2
                textBox3.Visible = false;
                label5.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            sizeCheck = true;
            if (comboBox2.SelectedIndex == 0)
            {
                gridSize = 4;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                gridSize = 5;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                gridSize = 6;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                gridSize = 7;
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                gridSize = 8;
            }
            else if (comboBox2.SelectedIndex == 5)
            {
                gridSize = 9;
            }
            else if (comboBox2.SelectedIndex == 6)
            {
                gridSize = 10;
            }
            
            //to remove the excess grids.
            for (int i = 0; i < Math.Sqrt(_chessBoardPanels.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(_chessBoardPanels.Length); j++)
                {
                    //remove from form
                    this.Controls.Remove(_chessBoardPanels[i, j]);
                    //release memory by disposing
                    _chessBoardPanels[i, i].Dispose();
                }
            }
            //to remove excess queens.
            for (int i = 0; i < 10; i++)
            {
                pictureBoxes[i].Visible = false;
            }
            Size s = new Size();
            s = this.Size;
            this.Size = new Size(25*(gridSize-4)+ s.Width, s.Height);
         
            
            createBoard();
        }

        public void generateRandomQueens()
        {
            Random rand = new Random();

            for (int i = 0; i < gridSize; i++)
            {
                int row = rand.Next(0, gridSize);
                queens[i].setX(i);
                queens[i].setY(row);

                pictureBoxes[i].Location = new Point(25 + tileSize * i, 25 + row * tileSize);
                pictureBoxes[i].Visible = true;
            }
        }
        public void reArrangeQueens()
        {
            for (int i = 0; i < gridSize; i++)
            {
                pictureBoxes[i].Location = new Point(25 + tileSize * queens[i].getX(), 25 + queens[i].getY() * tileSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox9.Visible = false;
            if (comboBox1.SelectedIndex == 0) //hill-climb
            {
                // generateRandomQueens();
                HillClimb hill = new HillClimb(gridSize, queens);
                // System.Threading.Thread.Sleep(2000);
                queens = hill.HillclimbingAlgorithm();
            }
            else if (comboBox1.SelectedIndex == 1) // simulated annealing
            {
                int temprature = int.Parse(textBox1.Text);
                int coolingFactor = int.Parse(textBox2.Text);

                SimulatedAnnealing simulAn = new SimulatedAnnealing(gridSize, queens, temprature, coolingFactor);
                queens = simulAn.simulatedAnnealingAlgorithm();
            }
            else if (comboBox1.SelectedIndex == 2) //local beam search
            {
                int states = int.Parse(textBox3.Text);
                LocalBeamSearch localBeam = new LocalBeamSearch(gridSize, queens, states);
                queens = localBeam.localBeamSearchAlgorithm();

            }
            else if (comboBox1.SelectedIndex == 3) //genetic algorithm
            {

            }
            
            reArrangeQueens();
            if (Heuristic.calculateHeuristicAllBoard(queens,gridSize) == 0)
                textBox9.Text = "SUCCESS!";
            else
                textBox9.Text = "FAIL!";

            textBox9.Visible = true;
        }
        //public void hillClimb()
        //{
        //    for (int i = 0; i < gridSize; i++)
        //    {
        //        queens[i]
        //    }
        //}
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //will show relevant items
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox9.Visible = false;
            if (allFieldsFilled())
            {
                generateRandomQueens();
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Please Fill All the Fields!");
            }
        }
        //to check if all the fields are filled
        public bool allFieldsFilled()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                return (algorithmCheck &&
                        sizeCheck
                        //textBox1.Text != ""&&
                        );
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int checkTemprature = int.Parse(textBox1.Text);
                int checkCoolingFactor = int.Parse(textBox2.Text);
                return (algorithmCheck &&
                        sizeCheck &&
                        //textBox1.Text != ""&&
                        checkTemprature > 0 && checkTemprature < 20000 &&
                        checkCoolingFactor >= 1 && checkCoolingFactor < 1000
                        );
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                int checkStates = int.Parse(textBox3.Text);
                return (algorithmCheck &&
                       sizeCheck &&
                       checkStates > 1 && checkStates < 10000
                       );
            }
            else if (comboBox1.SelectedIndex == 3)
            {

            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


//var picture = new PictureBox
//{
//    Size = new Size(60, 60),
//    Location = new Point(25, 25),
//    Image = Properties.Resources.queen,

//};
//Controls.Add(picture);