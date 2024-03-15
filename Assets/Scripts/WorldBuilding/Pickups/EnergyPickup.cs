using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class EnergyPickup : Pickup
    {
        [SerializeField]
        float energyPoints;

        protected override void ApplyPickup(Cat cat)
        {
            cat.ChangeEnergy(energyPoints);
        }
    }
}