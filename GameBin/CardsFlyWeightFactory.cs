using System;
using System.Collections.Generic;

namespace GameBin
{
    public class CardsFlyWeightFactory
    {
        private Dictionary<CardTypes, UICard> _cards =
            new Dictionary<CardTypes, UICard>();

        public UICard GetCard(CardTypes type)
        {
            UICard card = null;
            if (_cards.ContainsKey(type))
            {
                Console.WriteLine(type + " exists");
                card = _cards[type];
            }
            else
            {
                card = _cards[type] = new UICard(type);
            }
            return card;
        }
    }
}