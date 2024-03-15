using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class ShieldPickup : Pickup
    {
        [SerializeField]
        float shieldPoints;

        protected override void ApplyPickup(Cat cat)
        {
            cat.ChangeShield(shieldPoints);
        }
    }
}