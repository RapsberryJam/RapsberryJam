using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    [RequireComponent(typeof(Collider))]
    public abstract class Pickup : MonoBehaviour
    {
        [SerializeField]
        List<ParticleSystem> effects = new List<ParticleSystem>();
        [SerializeField]
        GameObject pickupView;
        [SerializeField]
        float animationDuration = 0.5f;

        protected abstract void ApplyPickup(Cat cat);

        bool pickupUsed;

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Cat>(out Cat cat) && !pickupUsed && cat.IsAlive)
            {
                pickupUsed = true;
                ApplyPickup(cat);

                foreach (ParticleSystem particles in effects)
                    particles.Play();

                pickupView.transform.DOScale(Vector3.zero, animationDuration);
            }
        }
    }
}
