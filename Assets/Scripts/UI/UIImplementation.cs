using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIImplementation : MonoBehaviour
    {
        [SerializeField]
        Cat cat;
        [SerializeField]
        Image energyBar;
        [SerializeField]
        Image shieldBar;

        public void Update()
        {
            energyBar.fillAmount = cat.EnergyNormalized;
            shieldBar.fillAmount = cat.ShieldNormalized;
        }
    }
}
