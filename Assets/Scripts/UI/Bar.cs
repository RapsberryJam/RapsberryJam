using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Bar : MonoBehaviour
    {
        [SerializeField]
        Image fillImage;
        [SerializeField]
        float lerpDuration = 0.33f;

        float lastValue;
        Tweener tween;

        public void UpdateValue(float newValue)
        {
            if (newValue == lastValue)
                return;

            tween?.Kill();
            tween = DOVirtual.Float(fillImage.fillAmount, newValue, lerpDuration, (float val) => fillImage.fillAmount = val);
        }
    }
}
