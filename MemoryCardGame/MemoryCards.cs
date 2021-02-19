using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorycardGame
{
    /// <summary>
    ///  class definition of the memory card
    /// </summary>
    public class MemoryCards
    {
        public CardClass[] Cards = new CardClass[size*2];
        const int size = 21;
        public Image[] CardImage = new Image[size];
        public Image BackGround;

        /// <summary>
        /// does the number exist
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool doesNumberExist(List<int> numbers, int number)
        {
            foreach (var item in numbers)
            {
                if (item == number) return true; ;
            }
            return false;
        }
        /// <summary>
        /// get random number
        /// </summary>
        /// <returns></returns>
        private int[] GetRandomNumber()
        {
            Random a = new Random();
            List<int> randomValues = new List<int>();

            while (randomValues.Count < 42)
            {
                int nextNum = a.Next(0, 42);
                if (!doesNumberExist(randomValues, nextNum)) randomValues.Add(nextNum);

            }

            return randomValues.ToArray();
        }

        /// <summary>
        /// Shuffle the cards
        /// </summary>
        public void ShuffleCards()
        {
            
            for (int i = 0; i < size; i++)
            {
                CardImage[i] = Image.FromFile($"Images\\rimage{i + 1}.jpg");
            }
            var result = GetRandomNumber();
            int mainindex = 0;
            for (int i = 0; i < size; i++)
            {
                Cards[result[mainindex]] = new CardClass(false, CardImage[i], i, false);
                mainindex++;
                Cards[result[mainindex]] = new CardClass(false, CardImage[i], i, false);
                mainindex++;
            }
        }

        /// <summary>
        /// get cards
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CardClass GetCard(int index)
        {
            return Cards[index];
        }

        /// <summary>
        /// is maching 
        /// </summary>
        /// <param name="index"></param>
        public void SetIsMatching(int index)
        {
            Cards[index].IsCardMatched = true;
        }

        /// <summary>
        /// change image status
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void ChnageImageStatus(int index, bool value)
        {
            Cards[index].ChnageImageStatus(value);
        }

        /// <summary>
        /// return card candiate
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int ReturnCandidateCard(int index)
        {
            for (int i = 0; i < size * 2; i++)
            {
                if (i != index && Cards[i].IsOpen && !Cards[i].IsCardMatched) return i;
            }
            return -1;
        }

        /// <summary>
        /// find much and disable
        /// </summary>
        /// <param name="candidateIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool FindMatchAndDisable(int candidateIndex, int index)
        {
            if (candidateIndex == -1) return false;

            return Cards[candidateIndex].MatchingCardIndex == Cards[index].MatchingCardIndex;
        }

       /// <summary>
       /// Index item not current
       /// </summary>
       /// <param name="index"></param>
       /// <returns></returns>
        public List<int> IndexItemNotCurrent(int index)
        {
            List<int> listOFOpenItems = new List<int>();
            for (int i = 0; i < size * 2; i++)
            {
                if (i != index && Cards[i].IsOpen && !Cards[i].IsCardMatched)
                {
                    listOFOpenItems.Add( i);
                }
            }
            return listOFOpenItems;
        }
    }
}
