using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class JumpActivator : Pickup
    {
        [SerializeField]
        float jumpHeight;

        protected override void ApplyPickup(Cat cat)
        {
            cat.Jump(jumpHeight);
        }
    }
}