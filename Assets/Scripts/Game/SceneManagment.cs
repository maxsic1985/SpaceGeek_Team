using System;
using GeekSpace.CONSTANT;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GeekSpace.EXTENSHION;
namespace GeekSpace
{
    public class SceneManagment : MonoBehaviour
    {
        Action OnChangeLevel;
        [SerializeField] internal GameData _gameData;
        public AudioMixer _audioMixer;
        Resolution[] _resolutionsArray;
        List<string> _resolutionsStringList;
        public Dropdown _resolutionDropDown;
        public Dropdown _qualityDropDown;
        public Slider _sliderAudio;
        private float _audioValue
        {
            get
            {
                return _sliderAudio.value;
            }
            set
            {
                value = _sliderAudio.value;
            }
        }
        public Animator _animator;
        private string _menuSceneName;
        private void OnLevelWasLoaded()
        {
            if (Application.loadedLevelName == _menuSceneName) OnChangeLevel.Invoke();
        }

        private void Start()
        {
            _menuSceneName = Application.loadedLevelName;
            OnChangeLevel += SetBtns;
            OnChangeLevel?.Invoke();
        }

        private void SetBtns()
        {
            GameObject.Find("StartGameBtn").gameObject.GetOrAddComponent<Button>().onClick.AddListener(SinglePlayPressed);
            GameObject.Find("Multiplayer").gameObject.GetOrAddComponent<Button>().onClick.AddListener(MultiplayerPlayPressed);
            GameObject.Find("SettingBtn").gameObject.GetOrAddComponent<Button>().onClick.AddListener(ShowMenu);
            GameObject.Find("QuitBtn").gameObject.GetOrAddComponent<Button>().onClick.AddListener(ExitPressed);
        }

        public void Awake()
        {
            _resolutionsStringList = new List<string>();
            _resolutionsArray = Screen.resolutions;
            foreach (var i in _resolutionsArray)
            {
                _resolutionsStringList.Add(i.width + "x" + i.height);
            }
            _resolutionDropDown.ClearOptions();
            _resolutionDropDown.AddOptions(_resolutionsStringList);
        }

        private void OnBecameVisible()
        {
            _sliderAudio.value = _audioValue;

        }

        public void ShowMenu()
        {
            var menuOpen = _animator.GetBool(SceeneConstManager.SETTING_MENU_TRIGGER);
            if (menuOpen)
            {
                _animator.SetBool(SceeneConstManager.SETTING_MENU_TRIGGER, false);

            }


            else
            {
                _animator.SetBool(SceeneConstManager.SETTING_MENU_TRIGGER, true);

            }

            _animator.gameObject.transform.SetAsLastSibling();
        }

        public void AudioVolume()
        {
            _audioMixer.SetFloat(SceeneConstManager.AUDIO_MIXER_VOLUME_LABEL, _audioValue);
        }

        public void Resolution()
        {

            Screen.SetResolution(_resolutionsArray[_resolutionDropDown.value].width, _resolutionsArray[_resolutionDropDown.value].height, true);
        }
        public void Quality()
        {
            QualitySettings.SetQualityLevel(_qualityDropDown.value, true);
        }

        public void SinglePlayPressed()
        {
            _gameData._GameType = GameType.SINGLE;
            if (TryGetComponent(out AudioSource audioSource))
            {
                audioSource.enabled = false;
            }
            SceneManager.LoadScene(SceeneConstManager.MAIN_SCENE_NAME);
        }

        public void MultiplayerPlayPressed()
        {
            _gameData._GameType = GameType.MULTIPLAYER;
            if (TryGetComponent(out AudioSource audioSource))
            {
                audioSource.enabled = false;
            }
            SceneManager.LoadScene("SampleScene");
        }

        public void ExitPressed()
        {
            Application.Quit();
        }
    }
}