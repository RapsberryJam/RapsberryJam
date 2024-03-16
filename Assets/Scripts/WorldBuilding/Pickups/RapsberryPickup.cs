using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Pickups
{
    public class RapsberryPickup : Pickup
    {
        [SerializeField]
        int rapsberryPoints = 1;

        GameManager manager;

        void Awake()
        {
            manager = FindObjectOfType<GameManager>();
        }

        protected override void ApplyPickup(Cat cat)
        {
            manager.AddScore(rapsberryPoints);
        }
    }
}