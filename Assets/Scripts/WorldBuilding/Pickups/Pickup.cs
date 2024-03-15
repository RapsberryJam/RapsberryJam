using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    [RequireComponent(typeof(Collider))]
    public abstract class Pickup : MonoBehaviour
    {
        public abstract void ApplyPickup(Cat cat);

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Cat>(out Cat cat))
                ApplyPickup(cat);
        }
    }
}
