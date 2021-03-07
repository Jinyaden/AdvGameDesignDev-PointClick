using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class DissolveInteraction : MonoBehaviour, IInteractor
    {
        [SerializeField] Material dissolveMaterial = null;
        private MeshRenderer meshRenderer;

        [SerializeField] float dissolveSpeed = 1f;

        private void Awake()
        {
            //get references to original material and renderer
            meshRenderer = GetComponent<MeshRenderer>();
        }


        public void Interact()
        {
            //add dissolve material onto object
            meshRenderer.material = dissolveMaterial;

            //dissolve then delete
            StartCoroutine(Dissolve());
        }

        IEnumerator Dissolve()
        {
            while (meshRenderer.material.GetFloat("_DissolveAmount") < 1.01f)
            {
                meshRenderer.material.SetFloat("_DissolveAmount", meshRenderer.material.GetFloat("_DissolveAmount") + 
                    dissolveSpeed * Time.deltaTime);
                yield return null;
            }
            if (meshRenderer.material.GetFloat("_DissolveAmount") >= 1.01f)
            {
                Destroy(gameObject);
            }
        }
    }
}
