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

namespace TicTacTocGame
{
   
    public partial class Form1 : Form
    {
        const int Width = 450;
        const int NoOfLines = 3;
        int UserIndex;

        Image image1;
        Image image2;
        bool flag = true;

        TicTacObject[,] TicTacObject = new TicTacObject[,]
        {
            {  new TicTacObject{ Checked=false,X_Min=0,   Y_Min=0,  X_Max=150,  Y_Max=150 },
               new TicTacObject{ Checked=false,X_Min=150, Y_Min=0,  X_Max=300,  Y_Max=150 },
               new TicTacObject{ Checked=false,X_Min=300, Y_Min=0,  X_Max=450,  Y_Max=150 }
            },
            {  new TicTacObject{ Checked=false,X_Min=0,   Y_Min=150,  X_Max=150,  Y_Max=300 },
               new TicTacObject{ Checked=false,X_Min=150, Y_Min=150,  X_Max=300,  Y_Max=300 },
               new TicTacObject{ Checked=false,X_Min=300, Y_Min=150,  X_Max=450,  Y_Max=300 }
            },
            {  new TicTacObject{ Checked=false,X_Min=0,   Y_Min=300,  X_Max=150,  Y_Max=450 },
               new TicTacObject{ Checked=false,X_Min=150, Y_Min=300,  X_Max=300,  Y_Max=450 },
               new TicTacObject{ Checked=false,X_Min=300, Y_Min=300,  X_Max=450,  Y_Max=450 }
            }
        };

        public Form1()
        {
            InitializeComponent();
            UserIndex = 1;
            flag = true;
        }

        /// <summary>
        /// A private funtion to fill the bacground including drawing the lines
        /// of the game
        /// </summary>
        /// <param name="g"></param>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        private void DrawTicTacToeBackground(Graphics g, Image image1, Image image2)
        {
            // fill the background of the rectangular
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            g.FillRectangle(whiteBrush, 0, 0, Width, Width);
            Pen pen = new Pen(Color.Black, 2);
            int start = 0;
            // Draw Lines 
            for (int i = 0; i < NoOfLines - 1; i++)
            {
                g.DrawLine(pen, 0, Width / NoOfLines + start, Width, Width / NoOfLines + start);
                g.DrawLine(pen, Width / NoOfLines + start, 0, Width / NoOfLines + start, Width);
                start += Width / NoOfLines;
            }

        }

        /// <summary>
        /// The function that load the images from the local rep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_Load(object sender, EventArgs e)
        {
            // make the form not resizable
            FormBorderStyle = FormBorderStyle.FixedSingle;

            if (File.Exists(@"O.png") && File.Exists(@"X.png"))
              {
                image1 = Image.FromFile(@"O.png");
                image2 = Image.FromFile(@"X.png");
            }
        }

        private void TicTacPictureBox_Paint(object sender, PaintEventArgs e)
        {
            DrawTicTacToeBackground(e.Graphics, image1, image2);
        }

        /// <summary>
        /// Get the object inde 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="userIndex"></param>
        /// <returns></returns>
        private Tuple<int, int, bool> GetObjectIndex(int x, int y, int userIndex)
        {
            for (int i = 0; i < NoOfLines; i++)
                for (int j = 0; j < NoOfLines; j++)
                {
                    if (x >= TicTacObject[i, j].X_Min
                        && x <= TicTacObject[i, j].X_Max
                        && y >= TicTacObject[i, j].Y_Min
                        && y <= TicTacObject[i, j].Y_Max
                        )
                    {
                        if (!TicTacObject[i, j].Checked)
                        {
                            TicTacObject[i, j].Checked = true;
                            TicTacObject[i, j].UserIndex = userIndex;
                            return new Tuple<int, int, bool>(i, j, false);
                        }
                        return new Tuple<int, int, bool>(i, j, true);
                    }
                }
            return new Tuple<int, int, bool>(0, 0, true);
        }

        private int ToggelUser(int currentUser)
        {
            return currentUser == 1 ? 2 : 1;
        }

        private bool WinGame(int currentUser)
        {
          
            // need to check vertical
            // need to check horizontal
            // need to check diagonal 
            int numberOfDiagonalChecked = 0;
            int numberOfRevDiagonalChecked = 0;
            for (int i = 0; i < NoOfLines; i++)
            {
                int numberOfHorizontalChecked = 0;
                int numberOfVerticalChecked = 0;

                for (int j = 0; j < NoOfLines; j++)
                {
                    if (TicTacObject[i, j].Checked && TicTacObject[i, j].UserIndex == currentUser)
                    {
                        numberOfHorizontalChecked++;
                    }
                    if (TicTacObject[j, i].Checked && TicTacObject[j, i].UserIndex == currentUser)
                    {
                        numberOfVerticalChecked++;
                    }
                    if (i == j && TicTacObject[i, j].Checked && TicTacObject[i, j].UserIndex == currentUser)
                    {
                        numberOfDiagonalChecked++;
                    }

                    if (i == NoOfLines - j - 1 && TicTacObject[i, j].Checked && TicTacObject[i, j].UserIndex == currentUser)
                    {
                        numberOfRevDiagonalChecked++;
                    }
                }
                if (numberOfHorizontalChecked == NoOfLines
                    || numberOfVerticalChecked == NoOfLines
                    || numberOfDiagonalChecked == NoOfLines
                    || numberOfRevDiagonalChecked == NoOfLines) return true;
            }
            return false;
        }

        private void TicTacPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                GraphicsUnit units = GraphicsUnit.Pixel;
                RectangleF srcRect = new RectangleF(0.0F, 0.0F, 150.0F, 150.0F);
                Graphics g = TicTacPictureBox.CreateGraphics();
                var result = GetObjectIndex(e.X, e.Y, UserIndex);
                if (!result.Item3)
                {
                    if (TicTacObject[result.Item1, result.Item2].Checked)
                        g.DrawImage(UserIndex == 1 ? image1 : image2, TicTacObject[result.Item1, result.Item2].X_Min, TicTacObject[result.Item1, result.Item2].Y_Min, srcRect, units);

                    Brush brush = new SolidBrush(Color.Black);
                    if (WinGame(UserIndex))
                    {
                        g.DrawString($"The winner is player = {UserIndex}", new Font("Arial", 28, FontStyle.Bold), brush, new Point(10, 200));
                        flag = false;

                    }
                    UserIndex = ToggelUser(UserIndex);
                }
            }

        }
    }
}
