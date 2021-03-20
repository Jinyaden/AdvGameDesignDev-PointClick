using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace COMP1288.PointClick.Jin
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] GameObject PauseUI = null;
        private GameManager manager => FindObjectOfType<GameManager>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && PauseUI != null)
            {
                PauseUI.SetActive(!PauseUI.activeSelf);
                if(Time.timeScale > 0) { Time.timeScale = 0; }
                else { Time.timeScale = 1; }
            }
        }

        public void ResetGame()
        {
            manager.DeleteAllPlayerPrefs();
            SceneManager.LoadScene("Beach");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
