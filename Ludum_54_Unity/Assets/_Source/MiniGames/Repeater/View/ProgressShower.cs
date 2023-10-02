using UnityEngine;

namespace MiniGames.Repeater.View
{
    public class ProgressShower : MonoBehaviour
    {
        [SerializeField] private GameObject[] progressImages;

        private int progressCounter;

        public void Restart()
        {
            foreach (var progressImage in progressImages)
                progressImage.SetActive(false);
            
            progressCounter = 0;
        }

        public void Up()
        {
            progressImages[progressCounter].SetActive(true);
            progressCounter++;
        }
    }
}