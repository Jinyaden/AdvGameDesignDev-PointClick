using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    enum loadlocations
    {
        Forest, 
        Beach,
        Mountain,
        Forest_Outer_Ruin,
        Inner_Ruin,
        Dungeon,
        Secret_Dungeon_Door
    }
    //Scenes to go to are Beach, Forest, Mountain, Outer Ruins, Inner Ruins
    public class SceneSelector : MonoBehaviour
    {
        [SerializeField] loadlocations locations;
        private Loader sceneLoader => FindObjectOfType<Loader>();

        //TODO: load scene depending on enum
        //TODO: Set player positions depending on enum place

        private void LoadSelectedScene()
        {
            switch (locations)
            {
                case loadlocations.Forest:
                    sceneLoader.LoadSceneWithDissolve("Forest");
                    break;
                case loadlocations.Beach:
                    sceneLoader.LoadSceneWithDissolve("Beach");
                    break;
                case loadlocations.Mountain:
                    sceneLoader.LoadSceneWithDissolve("Mountain");
                    break;
                case loadlocations.Forest_Outer_Ruin:
                    sceneLoader.LoadSceneWithDissolve("OuterRuin");
                    break;
                case loadlocations.Inner_Ruin:
                    sceneLoader.LoadSceneWithDissolve("InnerRuin");
                    break;
                case loadlocations.Dungeon:
                    sceneLoader.LoadSceneWithDissolve("Dungeon");
                    break;
                case loadlocations.Secret_Dungeon_Door:
                    sceneLoader.LoadSceneWithDissolve("InnerRuin");
                    break;

            }
        }

    }
}