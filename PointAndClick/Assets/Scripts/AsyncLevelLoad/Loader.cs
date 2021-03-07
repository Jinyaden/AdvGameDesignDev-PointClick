using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private string nameOfSceneToLoad = null;
        ILoad loaderManager;

        //TODO: Sort Loading Style, possible scene transitions

        private void Awake() // make sure to look for ILoad <_<
        {
            loaderManager = GetComponent<ILoad>();
        }

        public void LoadScene()
        {
            loaderManager.LoadScene(nameOfSceneToLoad);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
