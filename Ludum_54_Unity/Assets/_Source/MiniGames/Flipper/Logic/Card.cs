using System;
using Input.Interactions;
using UnityEngine;

namespace MiniGames.Flipper.Logic
{
    public class Card : MonoBehaviour, IClickable
    {
        public event Action<Card> OnSelected;

        public int index;
        
        public void Pressed(Vector2 pos) { }

        public void Released(Vector2 pos)
        {
            OnSelected?.Invoke(this);
        }

        public void Match()
        {
            gameObject.SetActive(false);
        }
    }
}