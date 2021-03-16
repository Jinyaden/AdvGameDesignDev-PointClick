using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace COMP1288.PointClick.Jin
{
    public class LoadManager : MonoBehaviour, ILoad
    {
        private AsyncOperation asyncLoadingOperation;
        [SerializeField] private GameObject loadingScreen = null;
        [SerializeField] private Slider progressBar = null;

        private void Start()
        {
            loadingScreen.SetActive(false); //just to make sure
        }

        public void LoadScene(string sceneName)
        {
            loadingScreen.SetActive(true);
            asyncLoadingOperation = SceneManager.LoadSceneAsync(sceneName);
            StartCoroutine(LoadAsync(sceneName));

        }

        IEnumerator LoadAsync(string sceneName)
        {
            while(!asyncLoadingOperation.isDone)
            {
                progressBar.value = Mathf.Clamp01(asyncLoadingOperation.progress / 0.9f);
                yield return null;
            }
        }
    }
}
