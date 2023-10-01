using System;
using System.Collections.Generic;
using System.Linq;
using MiniGames.Repeater.Data;
using Random = UnityEngine.Random;

namespace MiniGames.Repeater.Logic
{
    public class SequenceManager
    {
        private readonly SequenceManagerConfigSO _configSO;
        private readonly RepeatedGameSceneConfig _gameSceneConfig;

        private List<SequenceElement> _elementsLeft;

        public event Action OnStepRepeated;
        public event Action OnFullRepeated;
        public event Action OnMissed;

        public int CurrentStep { get; private set; }
        public int CurrentInStepStep { get; private set; }
        public List<Guid> CurrentSequence { get; private set; } = new List<Guid>();
        
        public SequenceManager(SequenceManagerConfigSO configSO, RepeatedGameSceneConfig gameSceneConfig)
        {
            _configSO = configSO;
            _gameSceneConfig = gameSceneConfig;

            Restart();
        }

        public void Restart()
        {
            _elementsLeft = _gameSceneConfig.Elements.ToList();
            CurrentStep = 0;
            CurrentSequence.Clear();
            
            GenerateSequence();
        }
        
        private void GenerateSequence()
        {
            for (int i = 0; i < _configSO.StepsCount; i++)
            {
                int randomElementIndex = Random.Range(0, _elementsLeft.Count);
                CurrentSequence.Add(_elementsLeft[randomElementIndex].Guid);

                _elementsLeft.RemoveAt(randomElementIndex);
            }
        }

        public void NextStep()
        {
            CurrentStep++;
            CurrentInStepStep = 0;
            if (CurrentStep > _configSO.StepsCount)
                OnFullRepeated?.Invoke();
        }

        public void CheckNext(Guid guid)
        {
            if (CurrentSequence[CurrentInStepStep] != guid)
            {
                OnMissed?.Invoke();
                return;
            }
            
            CurrentInStepStep++;
            if (CurrentInStepStep >= CurrentStep)
                OnStepRepeated?.Invoke();
        }
    }
}