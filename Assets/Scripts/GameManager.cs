using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WorldBuilding;

[Serializable]
public class SpeedDesc
{
    public int StartSecond;
    public float SpeedModifier;
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Cat cat;
    [SerializeField]
    WorldRunner worldRunner;
    [Space]
    [SerializeField]
    float energySinkSpeed = 15f;
    [SerializeField]
    List<SpeedDesc> speedRanges = new List<SpeedDesc>();

    int nextSpeedRangeIndex = 0;
    float gameTimer;
    float energySinkModifier = 1f;
    SpeedDesc nextSpeedRange;

    void Awake()
    {
        cat.CatExchausted += OnCatExchausted;
        cat.ShieldBroken += OnShieldBroken;

        nextSpeedRange = speedRanges.FirstOrDefault();
    }

    void Update()
    {
        gameTimer += Time.deltaTime;
        CheckSpeedRange();

        if (cat.IsAlive)
            cat.ChangeEnergy(- energySinkSpeed * energySinkModifier * Time.deltaTime);    
    }

    private void CheckSpeedRange()
    {
        if (nextSpeedRange != null && nextSpeedRange.StartSecond <= gameTimer)
        {
            SetGameSpeed(nextSpeedRange.SpeedModifier);

            nextSpeedRangeIndex++;
            nextSpeedRange = speedRanges.Count > nextSpeedRangeIndex
                ? speedRanges[nextSpeedRangeIndex]
                : null;
        }
    }

    private void SetGameSpeed(float speedModifier)
    {
        energySinkModifier = speedModifier;
        worldRunner.SetSpeed(speedModifier);
        cat.SetAnimationSpeed(speedModifier);
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
