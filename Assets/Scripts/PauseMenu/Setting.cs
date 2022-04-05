using UnityEngine;
using UnityEngine.UI;
using GeekSpace.CONSTANT;
namespace GeekSpace
{
    internal class Setting : SceneManagment
    {
        public static bool gameIsPaused;
        public Button _buttonSettings;
        public GameObject _menuSettingsUI;
        public Button _buttonPause;

        private void Start()
        {
            _buttonPause.onClick.AddListener(Paused);
            _buttonSettings.onClick.AddListener(Settings);
        }

        public void Settings()
        {
            _menuSettingsUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        void Paused()
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public new void ShowMenu()
        {
            var menuOpen = _animator.GetBool(SceeneConstManager.SETTING_MENU_TRIGGER);
            if (menuOpen) _animator.SetBool(SceeneConstManager.SETTING_MENU_TRIGGER, false);
            else _animator.SetBool(SceeneConstManager.SETTING_MENU_TRIGGER, true);
            _animator.gameObject.transform.SetAsLastSibling();
        }

        public new void AudioVolume()
        {
            _audioMixer.SetFloat(SceeneConstManager.AUDIO_MIXER_VOLUME_LABEL, _sliderAudio.value);
        }

        public new void Quality()
        {
            QualitySettings.SetQualityLevel(_qualityDropDown.value, true);
        }

        public new void ExitPressed()
        {
            Application.Quit();
        }
    }
}
