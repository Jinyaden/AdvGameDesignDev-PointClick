using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COMP1288.PointClick.Jin
{
    public class GameManager : MonoBehaviour
    {
        //Values for PlayerPrefs
        public int rustedKey = 0, goldenKey = 0, tikiStatue = 0, rope = 0, hammer = 0, rustySword = 0,
            nails = 0, crystalEye = 0, wood = 0, tribalCloth = 0;
        private string levelName => SceneManager.GetActiveScene().name; // to get the level we are on
        private Vector3 playerposition => GameObject.FindGameObjectWithTag("Player").transform.position; 


        private static GameManager _instance;
        public static GameManager Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<GameManager>();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            DeleteAllPlayerPrefs(); // test line

            GameObject.FindGameObjectWithTag("Player").transform.position = GetPlayerPositionFromPrefs();
            LoadItemValuesFromPrefs();
        }

        private void OnApplicationQuit()
        {
            //Save Player Position
            PlayerPrefs.SetFloat("PlayerX", playerposition.x);
            PlayerPrefs.SetFloat("PlayerY", playerposition.y);
            PlayerPrefs.SetFloat("PlayerZ", playerposition.z);

            //Save current Level
            PlayerPrefs.SetString("Level", levelName);

            //Save Item States
            SaveItemValuesToPrefs();

            PlayerPrefs.Save();
        }


        public void GetLevelToLoadNameFromPrefs()
        {
            PlayerPrefs.GetString("Level");
        }

        public Vector3 GetPlayerPositionFromPrefs()
        {
            //Single check cause its all that is needed 
            if (PlayerPrefs.HasKey("PlayerX"))
            {

                //Load Player Position
                float x = PlayerPrefs.GetFloat("PlayerX");
                float y = PlayerPrefs.GetFloat("PlayerY");
                float z = PlayerPrefs.GetFloat("PlayerZ");

                return new Vector3(x, y, z);
            }
            else
            {
                Debug.LogWarning("No Player Position found in Prefs");
                return GameObject.FindGameObjectWithTag("Player").transform.position;
            }
        }

        public void DeleteAllPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Deleting Player Prefs");
        }

        public void LoadItemValuesFromPrefs() // Set the values from playerprefs if any are stores
        {
            if (PlayerPrefs.HasKey("Rusted Key") != false)
            {
                rustedKey = PlayerPrefs.GetInt("Rusted Key");
            }

            if (PlayerPrefs.HasKey("Golden Key") != false)
            {
                goldenKey = PlayerPrefs.GetInt("Golden Key");
            }

            if (PlayerPrefs.HasKey("Tiki Statue") != false)
            {
                tikiStatue = PlayerPrefs.GetInt("Tiki Statue");
            }

            if (PlayerPrefs.HasKey("Rope") != false)
            {    
                rope = PlayerPrefs.GetInt("Rope");
            }

            if (PlayerPrefs.HasKey("Hammer") != false)
            {
                hammer = PlayerPrefs.GetInt("Hammer");
            }

            if (PlayerPrefs.HasKey("Rusty Sword") != false)
            { 
                rustySword = PlayerPrefs.GetInt("Rusty Sword");
            }

            if (PlayerPrefs.HasKey("Nails") != false)
            { 
                nails = PlayerPrefs.GetInt("Nails");
            }

            if (PlayerPrefs.HasKey("Crystal Eye") != false)
            {
                crystalEye = PlayerPrefs.GetInt("Crystal Eye");
            }

            if (PlayerPrefs.HasKey("Wood") != false)
            { 
                wood = PlayerPrefs.GetInt("Wood");
            }

            if (PlayerPrefs.HasKey("Tribal Cloth") != false)
            { 
                tribalCloth = PlayerPrefs.GetInt("Tribal Cloth");
            }
        }

        public void SaveItemValuesToPrefs() // Save Items Sates to Player Prefs
        {
                PlayerPrefs.SetInt("Rusted Key", rustedKey);
                PlayerPrefs.SetInt("Golden Key", goldenKey);
                PlayerPrefs.SetInt("Tiki Statue", tikiStatue);
                PlayerPrefs.SetInt("Rope", rope);
                PlayerPrefs.SetInt("Hammer", hammer);
                PlayerPrefs.SetInt("Rusty Sword", rustySword);
                PlayerPrefs.SetInt("Nails", nails);
                PlayerPrefs.SetInt("Crystal Eye", crystalEye);
                PlayerPrefs.SetInt("Wood", wood);
                PlayerPrefs.SetInt("Tribal Cloth", tribalCloth);
        }

    }
}
