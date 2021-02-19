using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemorycardGame
{
    public partial class Form1 : Form
    {
        const int size = 21;
      
        public Image BackGround;

        //    public CardClass[] Cards = new CardClass[size*2];
        public MemoryCards memoryCards = new MemoryCards();
        Button[] CardButtons = new Button[size * 2];
       
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            BackGround = Image.FromFile("images\\background.jpg");
        }

       /// <summary>
       /// Function load the background image
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        private void Form1_Load(object sender, EventArgs e)
        {
            int stepv = 0, steph = 0;
            int index = 0;
            memoryCards.ShuffleCards();
           
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    CardButtons[index] = new Button();
                    CardButtons[index].Location = new Point(stepv, steph);
                    CardButtons[index].Size = new Size(120, 120);
                    CardButtons[index].Image = BackGround;
                    CardButtons[index].Click += new System.EventHandler(this.buttong_Click);
                    stepv = stepv + 120;
                    Controls.Add(CardButtons[index]);
                    index++;
                }
                stepv = 0;
                steph = steph + 120;
            }
        }

        /// <summary>
        /// Event run when the button is clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     
        private void buttong_Click(object sender, EventArgs e)
        {
            var button = (sender as Button);
            var index = CardButtons.ToList().IndexOf(button);
            var card=memoryCards.GetCard(index);
            button.Image = card.Image;
         
            memoryCards.ChnageImageStatus(index, true);

            // rule 1 we can't have 3 cards open at the same time 
            // if there is more than 2 cards open 
            // we need to close them and open the new one

            var noofopenCards = memoryCards.IndexItemNotCurrent(index);
            if (noofopenCards.Count==2)
            {
                for (int i = 0; i < noofopenCards.Count; i++)
                {
                    memoryCards.ChnageImageStatus(noofopenCards[i], false);
                    CardButtons[noofopenCards[i]].Image = this.BackGround;
                }
                return;
            }

            var candidateIndex = memoryCards.ReturnCandidateCard(index);
            if (candidateIndex == -1) return;
            var findMatch = memoryCards.FindMatchAndDisable(candidateIndex, index);
            if(findMatch)
            {
                CardButtons[candidateIndex].Enabled = false;
                CardButtons[index].Enabled = false;

                memoryCards.SetIsMatching(index);
                memoryCards.SetIsMatching(candidateIndex);
            }
           
        }
      
    }
}
