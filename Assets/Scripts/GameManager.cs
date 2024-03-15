using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilding;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Cat cat;
    [SerializeField]
    WorldRunner worldRunner;

    void Awake()
    {
        cat.CatExchausted += OnCatExchausted;
        cat.ShieldBroken += OnShieldBroken;
    }

    void OnShieldBroken()
    {
        worldRunner.Stop();
    }

    void OnCatExchausted()
    {
        worldRunner.Stop();
    }
}
