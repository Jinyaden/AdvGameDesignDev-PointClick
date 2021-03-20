using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class UIManager : MonoBehaviour
    {
        private GameManager manager => FindObjectOfType<GameManager>();

        [SerializeField] GameObject rustedKeyUIElement = null, goldenKeyUIElement = null, tikiStatueUIElement = null, ropeUIElement = null,
                                    hammerUIElement = null, rustySwordUIElement = null, nailsUIElement = null, crystalEyeUIElement = null, 
                                    woodUIElement = null, tribalClothUIElement = null;

        private void FixedUpdate()
        {
            UIUpdate();
        }

        private void UIUpdate() // So inefficient lol
        {
            if (manager.rustedKey == 1) { rustedKeyUIElement.SetActive(true); }
            else { rustedKeyUIElement.SetActive(false); }

            if (manager.goldenKey == 1) { goldenKeyUIElement.SetActive(true); }
            else { goldenKeyUIElement.SetActive(false); }

            if (manager.tikiStatue == 1) { tikiStatueUIElement.SetActive(true); }
            else { tikiStatueUIElement.SetActive(false); }

            if (manager.rope == 1) { ropeUIElement.SetActive(true); }
            else { ropeUIElement.SetActive(false); }

            if (manager.hammer == 1) { hammerUIElement.SetActive(true); }
            else { hammerUIElement.SetActive(false); }

            if (manager.rustySword == 1) { rustySwordUIElement.SetActive(true); }
            else { rustySwordUIElement.SetActive(false); }

            if (manager.nails == 1) { nailsUIElement.SetActive(true); }
            else { nailsUIElement.SetActive(false); }

            if (manager.crystalEye == 1) { crystalEyeUIElement.SetActive(true); }
            else { crystalEyeUIElement.SetActive(false); }

            if (manager.wood == 1) { woodUIElement.SetActive(true); }
            else { woodUIElement.SetActive(false); }

            if (manager.tribalCloth == 1) { tribalClothUIElement.SetActive(true); }
            else { tribalClothUIElement.SetActive(false); }
        }
    }
}
