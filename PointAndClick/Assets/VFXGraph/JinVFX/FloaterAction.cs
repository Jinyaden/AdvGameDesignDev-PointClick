using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace GGJGU.Pickup
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class FloaterAction : MonoBehaviour
    {
        [Header("Needs a tag called Post Process Volume")]
        [SerializeField] float saturationAmountToSet = 50f;
        [SerializeField, Range(50, 100)] float resetPercent = 10f;
        private Volume saturation;

        private ColorAdjustments colAdjust;

        public bool startSaturation = false;

        private void Awake()
        {
            saturation = GameObject.FindGameObjectWithTag("Post Process Volume").GetComponent<Volume>();
        }
        private void Start()
        {
            saturation.profile.TryGet(out colAdjust);
        }
        private void FixedUpdate()
        {
            if (startSaturation == true)
            {
                if (colAdjust.saturation.value < saturationAmountToSet)
                { 
                    colAdjust.saturation.value += Time.deltaTime * saturationAmountToSet;
                }
                else if (colAdjust.saturation.value >= saturationAmountToSet)
                {
                    ResetSaturation();
                    Destroy(gameObject); //begone thot!
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            startSaturation = true;
        }

        void ResetSaturation()
        {
            colAdjust.saturation.value = -saturationAmountToSet / resetPercent * 100;
            Debug.Log("Reset Saturation to: " + colAdjust.saturation.value);
        }
    }
}
