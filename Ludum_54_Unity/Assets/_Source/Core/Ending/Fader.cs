using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Ending
{
    public class Fader : MonoBehaviour
    {
        public Image fadeImage;

        public bool onOnAwake;

        public Sequence fadeIn;
        public Sequence fadeOut;

        private void Awake()
        {
            if (onOnAwake)
            {
                fadeImage.color = new Color(255, 255, 255, 0);
                return;
            }
            
            fadeImage.color = new Color(255, 255, 255, 1);
            
            InitSequence();
        }

        public void FadeIn()
        {
            
        }

        public void FadeOut()
        {
            
        }

        private void InitSequence()
        {
            fadeIn = DOTween.Sequence();
            // fadeIn.set
        }
    }
}