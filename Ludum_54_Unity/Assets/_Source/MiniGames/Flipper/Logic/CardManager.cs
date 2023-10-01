using System;
using UnityEngine;

namespace MiniGames.Flipper.Logic
{
    public class CardManager : MonoBehaviour
    {
        [SerializeField] private Card[] cards;

        public Card firstCard;
        public Card secondCard;

        public bool isSecondCard;

        public event Action OnMatch;
        
        public void Bind()
        {
            foreach (var card in cards)
                card.OnSelected += Check;
        }

        public void Expose()
        {
            foreach (var card in cards)
                card.OnSelected -= Check;
        }

        public void Check(Card card)
        {
            if (!isSecondCard)
            {
                firstCard = card;
                isSecondCard = true;
                return;
            }
            
            isSecondCard = false;
            secondCard = card;
            if (firstCard.index != card.index || firstCard == card) 
                return;
            
            firstCard.Match();
            card.Match();
            
            OnMatch?.Invoke();
        }
    }
}