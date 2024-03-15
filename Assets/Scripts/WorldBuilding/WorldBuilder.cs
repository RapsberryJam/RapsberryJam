using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WorldBuilding
{
    public class WorldBuilder : MonoBehaviour
    {
        [field: SerializeField]
        public List<Chunk> ChunkLibrary = new List<Chunk>();

        [SerializeField]
        private int desiredChunkCount = 5;
        [SerializeField]
        Transform worldStartPoint;

        List<Chunk> activeChunks = new List<Chunk>();

        private void Awake()
        {
            BuildWorld();
        }

        private void BuildWorld()
        {
            var firstChunk = GetRandomChunk();
            ConnectChunk(worldStartPoint, firstChunk);

            for (int i = 1; i < desiredChunkCount; i++)
                AddNewChunk();
        }

        private Chunk GetRandomChunk()
        {
            return Instantiate(ChunkLibrary[Random.Range(0, ChunkLibrary.Count)], worldStartPoint);
        }

        private void ConnectChunk(Transform connectionPoint, Chunk chunkToConnect)
        {
            chunkToConnect.transform.rotation = connectionPoint.rotation;

            Vector3 offset = connectionPoint.position - chunkToConnect.StartConnectionPoint.position;
            chunkToConnect.transform.position += offset;

            activeChunks.Add(chunkToConnect);
        }

        public void AddNewChunk()
        {
            var newChunk = GetRandomChunk();
            ConnectChunk(activeChunks.Last().EndConnectionPoint, newChunk);
        }

        public void RemoveFirstChunk()
        {
            var firstChunk = activeChunks.First();
            activeChunks.Remove(firstChunk);
            Destroy(firstChunk.gameObject);
        }
    }
}