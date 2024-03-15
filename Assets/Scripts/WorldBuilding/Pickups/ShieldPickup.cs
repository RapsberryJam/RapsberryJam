using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class ShieldPickup : Pickup
    {
        [SerializeField]
        float shieldPoints;

        public override void ApplyPickup(Cat cat)
        {
            cat.ChangeShield(shieldPoints);
        }
    }
}