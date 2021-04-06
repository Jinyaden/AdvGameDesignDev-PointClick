using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    enum loadlocations
    {
        Forest, Beach, Mountain, Forest_Outer_Ruin, Inner_Ruin,Dungeon, Secret_Dungeon_Door
    }

    //Scenes to go to are Beach, Forest, Mountain, Outer Ruins, Inner Ruins
    public class SceneSelector : MonoBehaviour, IInteractor
    {
        [SerializeField] loadlocations locations;
        private Loader sceneLoader => FindObjectOfType<Loader>();

        public void Interact()
        {
            LoadSelectedScene();
        }

        //TODO: load scene depending on enum
        //TODO: Set player positions depending on enum place

        private void LoadSelectedScene()
        {
            switch (locations)
            {
                case loadlocations.Forest:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("Forest"));
                    break;
                case loadlocations.Beach:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("Beach"));
                    break;
                case loadlocations.Mountain:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("Mountain"));
                    break;
                case loadlocations.Forest_Outer_Ruin:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("OuterRuins"));
                    break;
                case loadlocations.Inner_Ruin:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("InnerRuins"));
                    break;
                case loadlocations.Dungeon:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("Dungeon"));
                    break;
                case loadlocations.Secret_Dungeon_Door:
                    StartCoroutine(sceneLoader.LoadSceneWithDissolve("InnerRuins"));
                    break;

            }
        }

    }
}