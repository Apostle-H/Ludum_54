using UnityEngine;

namespace Audio
{ 
    public class AudioManager : MonoBehaviour
    {
        public AudioSource audioSource;

        public static AudioManager Instance { get; private set; } = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void PlayOneShot(AudioClip oneShot) => audioSource.PlayOneShot(oneShot);
    }
}