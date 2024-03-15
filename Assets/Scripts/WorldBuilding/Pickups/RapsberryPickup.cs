using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class RapsberryPickup : Pickup
    {
        [SerializeField]
        float rapsberryPoints;

        public override void ApplyPickup(Cat cat)
        {
        }
    }
}