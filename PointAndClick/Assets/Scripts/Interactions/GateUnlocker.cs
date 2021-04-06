using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class GateUnlocker : MonoBehaviour, IInteractor
    {
        public void Interact()
        {
            //Unlock Gate if rusty key is in player prefs
            if (PlayerPrefs.GetInt("Rusted Key") == 1)
            {
                //Open Gate
                Debug.Log("Opening Gate!");
            }
        }
    }
}
