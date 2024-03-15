using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace WorldBuilding
{
    public class Chunk : MonoBehaviour
    {
        [field: SerializeField] public Transform StartConnectionPoint { get; private set; }
        [field: SerializeField] public Transform EndConnectionPoint { get; private set; }
    }
}
