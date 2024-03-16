using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class UIImplementation : MonoBehaviour
    {
        [SerializeField]
        Cat cat;
        [SerializeField]
        Bar energyBar;
        [SerializeField]
        Bar shieldBar;
        [SerializeField]
        GameObject gameOverScreen;
        [SerializeField]
        Button restartButton;
        [SerializeField]
        Transform bottomAnchor;

        private void Awake()
        {
            cat.CatExchausted += OnGameOver;
            cat.ShieldBroken += OnGameOver;
        }

        void Update()
        {
            energyBar.UpdateValue(cat.EnergyNormalized);
            shieldBar.UpdateValue(cat.ShieldNormalized);
        }

        void OnGameOver()
        {
            gameOverScreen.SetActive(true);
            restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single));

            gameOverScreen.transform.DOMoveY(bottomAnchor.position.y, 1.5f).SetDelay(1f).SetEase(Ease.OutBounce);
        }
    }
}
