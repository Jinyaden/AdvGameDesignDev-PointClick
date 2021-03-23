using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class CheckPickupStatus : MonoBehaviour
    {
        private GameManager manager => FindObjectOfType<GameManager>();
        Item itemTypeToCheck => GetComponent<SavePickup>().itemTypeToSave;

        private void Start()
        {
            CheckItemCollectedStatusByType();
        }

        private void CheckItemCollectedStatusByType()
        {
            switch (itemTypeToCheck)
            {
                case Item.Rusted_Key:
                    //Save Rusted Key
                    if(manager.rustedKey == 1) { Destroy(gameObject); }
                    break;

                case Item.Golden_Key:
                    //Save Golden Key
                    if (manager.goldenKey == 1) { Destroy(gameObject); }
                    break;

                case Item.Tiki_Statue:
                    //Save Tiki            
                    if (manager.tikiStatue == 1) { Destroy(gameObject); }
                    break;

                case Item.Rope:
                    //Save Rope            
                    if (manager.rope == 1) { Destroy(gameObject); }
                    break;

                case Item.Hammer:
                    //Save Hammer 
                    if (manager.hammer == 1) { Destroy(gameObject); }
                    break;

                case Item.Rusty_Sword:
                    //Save Sword             
                    if (manager.rustySword == 1) { Destroy(gameObject); }
                    break;

                case Item.Nails:
                    //Save Nails
                    if (manager.nails == 1) { Destroy(gameObject); }
                    break;

                case Item.Crystal_Eye:
                    //Save Eye
                    if (manager.crystalEye == 1) { Destroy(gameObject); }
                    break;

                case Item.Wood:
                    //Save wood
                    if (manager.wood == 1) { Destroy(gameObject); }
                    break;

                case Item.Tribal_Cloth:
                    //Save Tribal Cloth
                    if (manager.tribalCloth == 1) { Destroy(gameObject); }
                    break;
            }
        }
    }
}
