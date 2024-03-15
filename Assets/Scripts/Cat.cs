using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField]
    float InitialEnergy;
    [SerializeField]
    float InitialShield;

    public float EnergyNormalized => energy / InitialEnergy;
    public float ShieldNotmalized => shield / InitialShield;

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


}
