using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core.Ending
{
    public class Fader : MonoBehaviour
    {
        public CanvasGroup fade;
        public float fadeTime;

        public bool onOnAwake;

        public Sequence fadeIn;
        public Sequence fadeOut;

        private void Awake()
        {
            InitSequence();
            if (onOnAwake)
            {
                fade.alpha = 1f;
                return;
            }
            
            fade.alpha = 0f;
        }

        private void InitSequence()
        {
            fadeIn = DOTween.Sequence();
            fadeIn.SetAutoKill(fade);
            fadeIn.Pause();

            fadeIn.Append(fade.DOFade(1f, fadeTime));
            
            fadeOut = DOTween.Sequence();
            fadeOut.SetAutoKill(fade);
            fadeOut.Pause();

            fadeOut.Append(fade.DOFade(0f, fadeTime));
        }
    }
}