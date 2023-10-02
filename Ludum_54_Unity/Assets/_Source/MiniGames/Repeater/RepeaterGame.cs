using System;
using System.Linq;
using DG.Tweening;
using Input;
using MiniGames.Repeater.Data;
using MiniGames.Repeater.Logic;
using MiniGames.Repeater.View;

namespace MiniGames.Repeater
{
    public class RepeaterGame : IMiniGame
    {
        private readonly RepeatedGameSceneConfig _sceneConfig;
        private readonly SequenceManager _sequenceManager;
        private readonly SequenceElementFlasherConfigSO _flasherConfigSO;
        private readonly MainActions _inputActions;
        private readonly ProgressShower _progressShower;

        private Sequence _showFlashSequence;

        public event Action OnWin;
        public event Action OnLose;

        public RepeaterGame(RepeatedGameSceneConfig sceneConfig, SequenceManager sequenceManager, 
            SequenceElementFlasherConfigSO flasherConfigSO, MainActions inputActions, ProgressShower progressShower)
        {
            _sceneConfig = sceneConfig;
            _sequenceManager = sequenceManager;
            _flasherConfigSO = flasherConfigSO;
            _inputActions = inputActions;
            _progressShower = progressShower;
        }

        public void Start()
        {
            _progressShower.Restart();
            Bind();
            InitSequence();
            NextStep();
        }

        private void Bind()
        {
            _sequenceManager.OnStepRepeated += NextStep;
            _sequenceManager.OnStepRepeated += _progressShower.Up;
            _sequenceManager.OnFullRepeated += Win;
            _sequenceManager.OnMissed += Lose;
            
            foreach (var element in _sceneConfig.Elements)
            {
                element.OnChosen += _sequenceManager.CheckNext;
                element.OnChosen += FlashPress;
            }
        }

        private void Expose()
        {
            _sequenceManager.OnStepRepeated -= NextStep;
            _sequenceManager.OnStepRepeated -= _progressShower.Up;
            _sequenceManager.OnFullRepeated -= Win;
            _sequenceManager.OnMissed -= Lose;
            
            foreach (var element in _sceneConfig.Elements)
            {
                element.OnChosen -= _sequenceManager.CheckNext;
                element.OnChosen -= FlashPress;
            }
            
            _showFlashSequence.Kill();
        }
        
        public void Win()
        {
            End();
            OnWin?.Invoke();
        }

        public void Lose()
        {
            End();
            OnLose?.Invoke();
        }

        private void End() => Expose();

        private void FlashPress(Guid guid) => 
            _sceneConfig.ElementsFlashers.First(flasher => flasher.Element.Guid == guid).PressFlashSequence.Restart();

        private void NextStep()
        {
            _sequenceManager.NextStep();

            _showFlashSequence.Play();
        }

        private void CheckStep()
        {
            if (!(_showFlashSequence.position > _flasherConfigSO.FullShowFlashDuration * _sequenceManager.CurrentStep))
                return;
            
            _inputActions.Enable();
            _showFlashSequence.Rewind();
        }

        private void InitSequence()
        {
            _sequenceManager.Restart();
            
            _showFlashSequence?.Kill();
            _showFlashSequence = DOTween.Sequence();
            _showFlashSequence.SetAutoKill(false);
            _showFlashSequence.Pause();

            foreach (var guid in _sequenceManager.CurrentSequence)
            {
                _showFlashSequence.Append(_sceneConfig.ElementsFlashers.First(flasher => flasher.Element.Guid == guid).ShowFlashSequence);
            }

            _showFlashSequence.onPlay += _inputActions.Disable;
            _showFlashSequence.onUpdate += CheckStep;
            _showFlashSequence.onComplete += _inputActions.Enable;
        }
    }
}