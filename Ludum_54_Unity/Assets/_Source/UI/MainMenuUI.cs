using System;
using Core.Ending;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        public Fader fader;
        
        private void Awake()
        {
            playButton.onClick.AddListener(() => fader.fadeIn.Play());
        }

        private void Start()
        {
            fader.fadeIn.onComplete += Play;
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }
    }
}