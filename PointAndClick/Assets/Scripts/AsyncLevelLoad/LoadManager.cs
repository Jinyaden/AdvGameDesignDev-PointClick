using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace COMP1288.PointClick.Jin
{
    public class LoadManager : MonoBehaviour, ILoad
    {
        private AsyncOperation asyncLoadingOperation;
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider progressBar;

        private void Start()
        {
            loadingScreen.SetActive(false); //just to make sure
        }

        public void LoadScene(string sceneName)
        {
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
