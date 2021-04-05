using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace COMP1288.PointClick.Jin
{
    public class Loader : MonoBehaviour
    {
        //[SerializeField] Material mat;

        //UniversalRenderPipelineAsset urpAsset = (UniversalRenderPipelineAsset)GraphicsSettings.renderPipelineAsset;
        //ScriptableRenderer render = urpAsset.scriptableRenderer;
        //new ScriptableRendererFeature renderer => TryGetComponent<BlitRenderPassFeature>();
        //public Settings settings = Settings.instance;
        //private MeshRenderer meshRenderer => GetComponent<MeshRenderer>();//get references to renderer
        //BlitRenderPassFeature outlineData = FindObjectOfType<BlitRenderPassFeature>();

        [SerializeField] private ForwardRendererData renderData = null; // Renderer Asset
        [SerializeField] private string featureName = null; // Feature name to look for


        //[SerializeField] Material mat = null;
        [SerializeField] private float sceneDissolveSpeed = 0.5f;



        //[SerializeField] private string nameOfSceneToLoad = null;
        ILoad loaderManager => GetComponent<ILoad>();

        private void Awake() // make sure to look for ILoad <_<
        {
            //loaderManager = GetComponent<ILoad>();
            //urpAsset.scriptableRenderer
        }

        private void Start()
        {
            //sceneDissolveMat.SetFloat("_DissolveAmount", -1f);

            SetDissolveMaterialBlackScreen();
            StartCoroutine(DissolveScreenIn());
        }

        private void FixedUpdate()
        {
            //Test Zombie Code
            //Debug.Log(mat.name);
            //if (mat.GetFloat("_DissolveAmount") < 1.01f)
            //{
            //    mat.SetFloat("_DissolveAmount", mat.GetFloat("_DissolveAmount") +
            //        sceneDissolveSpeed * Time.deltaTime);
            //    Debug.Log("Dissolving out! Material value is: " + mat.GetFloat("_DissolveAmount").ToString());
            //    renderData.SetDirty();
            //}
        }

        public void SceneToLoadByName(string nameofScene)
        {
            loaderManager.LoadScene(nameofScene);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadFromMainMenu()
        {
            SceneToLoadByName("Forest");
        }

        private bool TryGetFeature(out ScriptableRendererFeature feature)
        {
            feature = renderData.rendererFeatures.Where((f) => f.name == featureName).FirstOrDefault();
            return feature != null;
        }

        public void SetDissolveMaterialBlackScreen()
        {
            if (TryGetFeature(out var feature))
            {
                var blitFeature = feature as BlitRenderPassFeature;
                var material = blitFeature.Material;

                material.SetFloat("_DissolveAmount", -1.01f); // set this on start so screen is black
                renderData.SetDirty();
                Debug.Log("Setting material to -1: name: " + material.name);
            }
        }


        public IEnumerator DissolveScreenIn()
        {
            if (TryGetFeature(out var feature))
            {
                var blitFeature = feature as BlitRenderPassFeature;
                var material = blitFeature.Material;

                while (material.GetFloat("_DissolveAmount") < 1.01f)
                {
                    material.SetFloat("_DissolveAmount", material.GetFloat("_DissolveAmount") +
                        sceneDissolveSpeed * Time.deltaTime);
                    Debug.Log("Dissolving out! Material value is: " + material.GetFloat("_DissolveAmount").ToString());
                    yield return null;
                    renderData.SetDirty();
                }
            }
        }

        public IEnumerator LoadSceneWithDissolve(string nameOfSceneToLoad)
        {
            if (TryGetFeature(out var feature))
            {
                var blitFeature = feature as BlitRenderPassFeature;
                var material = blitFeature.Material;

                while (material.GetFloat("_DissolveAmount") > -1.01f)
                {
                    material.SetFloat("_DissolveAmount", material.GetFloat("_DissolveAmount") -
                        sceneDissolveSpeed * Time.deltaTime);
                    Debug.Log("Dissolving in!");
                    yield return null;
                    renderData.SetDirty();
                }

                if (material.GetFloat("_DissolveAmount") <= -1.01f)
                {
                    SceneToLoadByName(nameOfSceneToLoad);
                    renderData.SetDirty();
                }
            }
        }
    }
}
