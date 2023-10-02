using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio
{
    public class AudioSettings : MonoBehaviour
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        [SerializeField] private AudioMixer mixer;

        private const string MASTER_VOLUME = "MASTER_VOLUME";
        private const string MUSIC_VOLUME = "MUSIC_VOLUME";
        private const string SFX_VOLUME = "SFX_VOLUME";

        private const float SLIDERS_MIN_VALUE = 0.001f;

        private void Start()
        {
            Load();
            Bind();
        }

        private void OnDisable()
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME, masterSlider.value);
        }

        private void Load()
        {
            masterSlider.minValue = SLIDERS_MIN_VALUE;

            masterSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME, 1f);

            SetMasterVolume(masterSlider.value);
        }

        private void Bind()
        {
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
        }

        private void SetMasterVolume(float value)
        {
            mixer.SetFloat(MASTER_VOLUME, Mathf.Log10(value == 0 ? 0.001f : value) * 20);
        }

        private void SetMusicVolume(float value)
        {
            mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value == 0 ? 0.001f : value) * 20);
        }

        private void SetSfxVolume(float value)
        {
            mixer.SetFloat(SFX_VOLUME, Mathf.Log10(value == 0 ? 0.001f : value) * 20);
        }
    }
}