using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekSpace
{
    public class Pause : MonoBehaviour
    {
        public GameObject _menuPausedUI;
        public GameObject _LooseMenu;
        public Button _buttonPause;
        public static bool gameIsPaused { get; set; }

        private void Start()
        {
            _buttonPause.onClick.AddListener(Paused);
            _menuPausedUI.SetActive(false);
            _LooseMenu.SetActive(false);
        }
        public void ShowLooseMenu()
        {
            _LooseMenu.SetActive(true);
            gameIsPaused = true;
            ChangeSimulatedPhisicsVisibleEnemy(gameIsPaused);
        }

        public void Resume()
        {
            _menuPausedUI.SetActive(false);
            gameIsPaused = false;
            ChangeSimulatedPhisicsVisibleEnemy(gameIsPaused);
        }

        public void Paused()
        {

            if (_menuPausedUI.activeSelf == true)
            {
                _menuPausedUI.SetActive(false);
                gameIsPaused = false;
            }
            else
            {
                _menuPausedUI.SetActive(true);
                gameIsPaused = true;
            }
            ChangeSimulatedPhisicsVisibleEnemy(gameIsPaused);
        }

        private static void ChangeSimulatedPhisicsVisibleEnemy(bool isPaused)
        {
            var rb = FindObjectsOfType<Rigidbody2D>();
            foreach (var item in rb)
            {
                if (isPaused) item.simulated = false;
                else item.simulated = true;
            }
        }

        public void LoadMenu()
        {
            var menu = FindObjectOfType<SceneManagment>();
            menu.ShowMenu();
        }

        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
            gameIsPaused = false;
        }

        public void Exit()
        {
            SceneManager.LoadScene("MainMenuScene");
            gameIsPaused = false;
        }
    }
}
