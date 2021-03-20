using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public enum Item
    {
        Rusted_Key, Golden_Key, Tiki_Statue, Rope, Hammer, Rusty_Sword,
        Nails, Crystal_Eye, Wood, Tribal_Cloth
    }
    [RequireComponent(typeof(CheckPickupStatus))]
    public class SavePickup : MonoBehaviour
    {
        private GameManager manager => FindObjectOfType<GameManager>();

        [SerializeField] public Item itemTypeToSave = 0;

        private void OnDestroy()
        {
            SaveByItemType();
        }

        private void SaveByItemType()
        {
            switch (itemTypeToSave)
            {
                case Item.Rusted_Key:
                    //Save Rusted Key
                    PlayerPrefs.SetInt("Rusted Key", manager.rustedKey = 1);
                    SaveItemState();
                    break;

                case Item.Golden_Key:
                    //Save Golden Key
                    PlayerPrefs.SetInt("Golden Key", manager.goldenKey = 1);
                    SaveItemState();
                    break;

                case Item.Tiki_Statue:
                    //Save Tiki            
                    PlayerPrefs.SetInt("Tiki Statue", manager.tikiStatue = 1);
                    SaveItemState();
                    break;

                case Item.Rope:
                    //Save Rope            
                    PlayerPrefs.SetInt("Rope", manager.rope = 1);
                    SaveItemState();
                    break;

                case Item.Hammer:
                    //Save Hammer 
                    PlayerPrefs.SetInt("Hammer", manager.hammer = 1);
                    SaveItemState();
                    break;

                case Item.Rusty_Sword:
                    //Save Sword             
                    PlayerPrefs.SetInt("Rusty Sword", manager.rustySword = 1);
                    SaveItemState();
                    break;

                case Item.Nails:
                    //Save Nails
                    PlayerPrefs.SetInt("Nails", manager.nails = 1);
                    SaveItemState();
                    break;

                case Item.Crystal_Eye:
                    //Save Eye
                    PlayerPrefs.SetInt("Crystal Eye", manager.crystalEye = 1);
                    SaveItemState();
                    break;

                case Item.Wood:
                    //Save wood
                    PlayerPrefs.SetInt("Wood", manager.wood = 1);
                    SaveItemState();
                    break;

                case Item.Tribal_Cloth:
                    //Save Tribal Cloth
                    PlayerPrefs.SetInt("Tribal Cloth", manager.tribalCloth = 1);
                    SaveItemState();
                    break;
            }
        }

        void SaveItemState()
        {
            PlayerPrefs.Save(); // a bit of manual saving
        }
    }
}
