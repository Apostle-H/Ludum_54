using System;
using System.Globalization;
using DG.Tweening;
using MiniGames.Flipper.Logic;
using MiniGames.Flipper.View;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace MiniGames.Flipper
{
    public class FlipperGame : MonoBehaviour, IMiniGame
    {
        [SerializeField] private CardManager cardManager;
        [SerializeField] private CardsRandomizer cardsRandomizer;
        [SerializeField] private float timeToComplete;
        [FormerlySerializedAs("progressShower")] [SerializeField] private ProgressShowerFlipper progressShowerFlipper; 

        [SerializeField] private TextMeshProUGUI text;
        
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
            text.gameObject.SetActive(true);
            progressShowerFlipper.Restart();
            Bind(); 
            
            cardsRandomizer.Randomize();
        }

        private void Bind()
        {
            cardManager.OnMatch += Count;
            cardManager.OnMatch += progressShowerFlipper.Up;
            cardManager.Bind();
        }

        private void Expose()
        {
            
            text.gameObject.SetActive(false);
            cardManager.OnMatch -= Count;
            cardManager.OnMatch -= progressShowerFlipper.Up;
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
            text.text = ((int)MathF.Ceiling(timer)).ToString();
            if (timer <= 0)
            {
                text.text = "0";
                play = false;
                Expose();
                OnLose?.Invoke();
            }
        }
    }
}