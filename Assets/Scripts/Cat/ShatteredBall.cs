using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatteredBall : MonoBehaviour
{
    [SerializeField]
    float force;

    Rigidbody[] shatters;

    private void Awake()
    {
        shatters = GetComponentsInChildren<Rigidbody>();
    }

    void Start()
    {
        
        foreach(Rigidbody shatter in shatters)
        {
            Vector3 forceDirection = (shatter.position - transform.position).normalized;
            shatter.AddForce(force * forceDirection, ForceMode.Impulse);
        }
    }
}
