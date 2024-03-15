using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class RapsberryPickup : Pickup
    {
        [SerializeField]
        float rapsberryPoints;

        protected override void ApplyPickup(Cat cat)
        {
        }
    }
}