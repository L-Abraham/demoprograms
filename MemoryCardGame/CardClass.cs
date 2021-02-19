using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemorycardGame
{
    public class CardClass
    {
        public CardClass(bool isOpen, Image image, int machingCardindex, bool isCardMutched)
        {
            IsOpen = isOpen;
            Image = image;
            MatchingCardIndex = machingCardindex;
            IsCardMatched = isCardMutched;

        }
        public bool IsOpen;
        public Image Image;
        public bool IsCardMatched;

        public int MatchingCardIndex;

        public void ChnageImageStatus(bool Checked)
        {
            IsOpen = Checked;
        }

        public bool IsMachedCorrect(int OpenIndex)
        {
            return MatchingCardIndex == OpenIndex;
        }
        
    }
}
