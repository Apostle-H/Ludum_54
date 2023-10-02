using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        private void Awake()
        {
            playButton.onClick.AddListener(Play);
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }
    }
}