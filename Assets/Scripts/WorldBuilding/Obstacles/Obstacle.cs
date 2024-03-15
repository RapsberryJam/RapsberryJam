using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilding.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]
        float shieldDamage;
        [SerializeField]
        float energyDamage;

        [SerializeField]
        List<ParticleSystem> effects = new List<ParticleSystem>();
        [SerializeField]
        List<Rigidbody> rigidBodies = new List<Rigidbody>();

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Cat>(out Cat cat))
            {
                cat.ChangeShield(-shieldDamage);
                cat.ChangeEnergy(-energyDamage);

                Vector3 forceVector = 35f * ((transform.position - cat.transform.position).normalized + (0.25f * Random.insideUnitSphere));
                foreach (Rigidbody body in rigidBodies)
                {
                    body.isKinematic = false;
                    body.AddForce(forceVector, ForceMode.Impulse);
                }

                foreach (ParticleSystem particles in effects)
                    particles.Play();

                Destroy(this);
            }
        }
    }
}
