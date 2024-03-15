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

    public bool IsAlive => shield > 0 && energy > 0;
    public float EnergyNormalized => energy / InitialEnergy;
    public float ShieldNormalized => shield / InitialShield;

    public Action CatExchausted;
    public Action ShieldBroken;

    float energy;
    float shield;

    void Awake()
    {
        shield = InitialShield;
        energy = InitialEnergy;
    }

    public void ChangeEnergy(float delta)
    {
        energy = Mathf.Clamp(energy + delta,0,InitialEnergy);

        if (energy == 0)
            CatExchausted?.Invoke();
    }

    public void ChangeShield(float delta)
    {
        shield = Mathf.Clamp(shield + delta, 0, InitialShield);

        if(shield == 0)
            ShieldBroken?.Invoke();
    }

    public void Jump(float height)
    {
       Sequence jumpSequence = DOTween.Sequence();

        Vector3 jumpDeltaY = new Vector3(0, height, 0);

        jumpSequence.Append(transform.DOBlendableMoveBy(jumpDeltaY, 0.5f).SetEase(Ease.InCubic))
            .Append(transform.DOBlendableMoveBy(-jumpDeltaY, 0.5f).SetEase(Ease.OutCubic))
            .Append(transform.DOPunchScale(0.25f * Vector3.one, 5));

        jumpSequence.Play();
    }
}
