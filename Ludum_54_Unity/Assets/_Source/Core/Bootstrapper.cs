using Core.Ending;
using Core.Games;
using DG.Tweening;
using Input;
using Input.Interactors;
using Memories;
using UnityEngine;
using VContainer;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject memoriesStarter;
        [SerializeField] private EndingShower endingShower;
        public Fader fader;
        
        private MainActions _inputActions;
        private MouseHandler _mouseHandler;

        private MiniGamesManager _miniGamesManager;
        
        private MemoriesGame _game;

        public textSwitcher textSwitcher;

        private int dayCounter;
        
        [Inject]
        private void Init(MainActions inputActions, MouseHandler mouseHandler, MiniGamesManager miniGamesManager, MemoriesGame game)
        {
            _inputActions = inputActions;
            _mouseHandler = mouseHandler;

            _game = game;

            _miniGamesManager = miniGamesManager;
            _miniGamesManager.OnGamesComplete += OpenPlayMemories;
            _game.OnGameEnded += Rastart;
        }

        private void Start()
        {
            fader.fadeIn.onPlay += textSwitcher.Next;
            fader.fadeIn.onComplete += () => fader.fadeOut.Restart();
            fader.fadeOut.onComplete += _miniGamesManager.Restart;

            fader.fade.DOFade(0, fader.fadeTime);
        }

        private void Rastart()
        {
            fader.fadeIn.Restart();
        }

        private void Awake()
        {
            _inputActions.Enable(); 
            _mouseHandler.Bind();
        }

        private void OpenPlayMemories()
        {
            if (dayCounter >= 7)
            {
                endingShower.Show();
            }
            memoriesStarter.SetActive(true);
            dayCounter++;
        }
    }
}