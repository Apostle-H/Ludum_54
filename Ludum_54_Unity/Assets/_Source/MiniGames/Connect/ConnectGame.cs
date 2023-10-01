using System;
using MiniGames.Connect.Data;
using MiniGames.Connect.Logic;
using MiniGames.Connect.Signals;
using VContainer;

namespace MiniGames.Connect
{
    public class ConnectGame : IMiniGame
    {
        private ConnectGameSceneConfig _sceneScope;
        
        public event Action OnWin;
        public event Action OnLose;

        private ConnectionEndPlacedCorrectSignal _connectionEndPlacedCorrectSignal;
        private ConnectionEndPlacedWrongSignal _connectionEndPlacedWrongSignal;

        private int _counter;
        
        [Inject]
        private void Init(ConnectGameSceneConfig sceneScope)
        {
            _sceneScope = sceneScope;

            _connectionEndPlacedCorrectSignal = deVoid.Utils.Signals.Get<ConnectionEndPlacedCorrectSignal>();
            _connectionEndPlacedWrongSignal = deVoid.Utils.Signals.Get<ConnectionEndPlacedWrongSignal>();
            
            _connectionEndPlacedCorrectSignal.AddListener(Count);
            _connectionEndPlacedWrongSignal.AddListener(Lose);
        }

        public void Start()
        {
            _counter = 0;
            _sceneScope.EndSocketsRandomizer.Randomize();
        }

        private void End()
        {
            foreach (var connectionEnd in _sceneScope.ConnectionEnds)
            {
                connectionEnd.ToStart();
            }
        }
        
        private void Count(ConnectionEnd connectionEnd)
        {
            _counter++;
            if (_counter >= 4)
            {
                Win();  
            }
        }

        private void Win()
        {
            End();
            OnWin?.Invoke();
        }

        private void Lose(ConnectionEnd connectionEnd)
        {
            End();
            OnLose?.Invoke();
        }
    }
}