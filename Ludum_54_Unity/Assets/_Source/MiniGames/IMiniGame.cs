using System;

namespace MiniGames
{
    public interface IMiniGame
    {
        public event Action OnWin; 
        public event Action OnLose; 
        
        public void Start();
    }
}