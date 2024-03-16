using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField]
    float InitialEnergy;
    [SerializeField]
    float InitialShield;
    [SerializeField]
    CatAnimator animator;
    [SerializeField]
    GameObject ball;
    [SerializeField]
    GameObject shatteredBall;

    public bool IsAlive => shield > 0 && energy > 0;
    public float EnergyNormalized => energy / InitialEnergy;
    public float ShieldNormalized => shield / InitialShield;

    public Action CatExchausted;
    public Action ShieldBroken;

    float energy;
    float shield;
    Rigidbody rigidBody;

    void Awake()
    {
        shield = InitialShield;
        energy = InitialEnergy;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass = Vector3.down;
    }

    public void ChangeEnergy(float delta)
    {
        energy = Mathf.Clamp(energy + delta,0,InitialEnergy);

        if (energy == 0)
        {
            CatExchausted?.Invoke();
            rigidBody.isKinematic = false;
            rigidBody.AddForceAtPosition(5 * Vector3.forward, transform.position + UnityEngine.Random.insideUnitSphere, ForceMode.Impulse);
            animator.PlayFall();
        }
    }

    public void ChangeShield(float delta)
    {
        if (delta < 0)
            animator.PlayPunch();

        shield = Mathf.Clamp(shield + delta, 0, InitialShield);

        if (shield == 0)
        {
            ShieldBroken?.Invoke();
            ball.SetActive(false);
            shatteredBall.SetActive(true);
            animator.PlayFall();
        }
    }

    public void Jump(float height)
    {
        animator.PlayJump(height);
    }

    public void SetAnimationSpeed(float speedModifier)
    {
        animator.SetSpeedModifier(speedModifier);
    }
}
