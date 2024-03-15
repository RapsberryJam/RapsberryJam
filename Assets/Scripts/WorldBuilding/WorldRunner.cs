using System;
using System.Collections;
using System.Collections.Generic;
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

        bool isRunning = false;

        void Start()
        {
            isRunning = true;
        }

        void Update()
        {
            if (isRunning)
                worldContainer.position -= new Vector3(0, 0, WorldSpeed * Time.deltaTime);
        }

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
