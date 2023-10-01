using System;
using DG.Tweening;
using MiniGames.Flipper.Logic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MiniGames.Flipper
{
    public class FlipperGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private CardManager cardManager;
        [SerializeField] private CardsRandomizer cardsRandomizer;
        [SerializeField] private float timeToComplete;
        
        public event Action OnWin;
        public event Action OnLose;

        private int counter;
        private float timer;

        private bool play;

        void IMiniGame.Start()
        {
            counter = 0;
            timer = timeToComplete;
            play = true;
            Bind(); 
            
            cardsRandomizer.Randomize();
        }

        private void Bind()
        {
            cardManager.OnMatch += Count;
            cardManager.Bind();
        }

        private void Expose()
        {
            cardManager.OnMatch -= Count;
            cardManager.Expose();
        }

        private void Count()
        {
            counter++;
            if (counter >= 8)
            {
                Expose();
                OnWin?.Invoke();
            }
        }

        private void Update()
        {
            if (!play)
            {
                return;
            }
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                play = false;
                Expose();
                OnLose?.Invoke();
            }
        }
    }
}