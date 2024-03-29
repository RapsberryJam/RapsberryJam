using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace WorldBuilding
{
    public class WorldRunner : MonoBehaviour
    {
        [field: SerializeField]
        public float WorldSpeed { get; private set; }

        [SerializeField]
        WorldBuilder worldBuilder;
        [SerializeField]
        Transform worldContainer;

        bool isRunning;
        bool acceptSpeedUpdate;
        float worldSpeedModifier = 1f;

        void Start()
        {
            isRunning = true;
            acceptSpeedUpdate = true;
        }

        public void Stop()
        {
            acceptSpeedUpdate = false;

            DOTween.To(speed => WorldSpeed = speed, WorldSpeed, 0, 0.5f)
                .onComplete += () => isRunning = false;
        }

        public void SetSpeed(float speedModifier)
        {
            if (acceptSpeedUpdate)
                worldSpeedModifier = speedModifier;
        }

        void Update()
        {
            if (isRunning)
                worldContainer.position -= new Vector3(0, 0, WorldSpeed * worldSpeedModifier * Time.deltaTime);
        }

        //If chunk moves to trigger - it is time to rebuild chunks
        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Chunk>() != null)
            {
                worldBuilder.RemoveFirstChunk();
                worldBuilder.AddNewChunk();
            }
        }
    }
}
