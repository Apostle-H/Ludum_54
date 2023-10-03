using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Ending
{
    public class Fader : MonoBehaviour
    {
        public Image fadeImage;
        public float fadeTime;

        public bool onOnAwake;

        public Sequence fadeIn;
        public Sequence fadeOut;

        private void Awake()
        {
            InitSequence();
            if (onOnAwake)
            {
                fadeImage.color = new Color(0, 0, 0, 1);
                return;
            }
            
            fadeImage.color = new Color(0, 0, 0, 0);
        }

        private void InitSequence()
        {
            fadeIn = DOTween.Sequence();
            fadeIn.SetAutoKill(fadeImage);
            fadeIn.Pause();

            fadeIn.Append(fadeImage.DOFade(1f, fadeTime));
            
            fadeOut = DOTween.Sequence();
            fadeOut.SetAutoKill(fadeImage);
            fadeOut.Pause();

            fadeOut.Append(fadeImage.DOFade(0f, fadeTime));
        }
    }
}