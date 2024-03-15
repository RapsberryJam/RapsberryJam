using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace WorldBuilding
{
    public enum Direction { Left, Right }

    public class RunLines : MonoBehaviour
    {
        [SerializeField]
        float switchingLineDuration = 0.4f;
        [SerializeField]
        List<Transform> linePositions = new List<Transform>();
        [SerializeField]
        Cat cat;

        bool switchLineInProgress;
        bool switchingAvailable;
        int currentLineIndex;
        int maxLineIndex;
        Tweener currentTween;

        void Awake()
        {
            maxLineIndex = linePositions.Count - 1;
            currentLineIndex = linePositions.Count / 2;
            switchingAvailable = true;

            cat.ShieldBroken += OnCatDead;
            cat.CatExchausted += OnCatDead;
        }

        public void SwitchLine(Direction direction)
        {
            int newLineIndex = direction == Direction.Left
                ? currentLineIndex - 1
                : currentLineIndex + 1;

            if (CanSwitchLine(newLineIndex))
            {
                Vector3 deltaMoveX = new Vector3(linePositions[newLineIndex].position.x - linePositions[currentLineIndex].position.x, 0, 0);
                currentLineIndex = newLineIndex;
                switchLineInProgress = true;

                currentTween = cat.transform.DOBlendableMoveBy(deltaMoveX, switchingLineDuration)
                    .SetEase(Ease.InQuint);

                currentTween.onComplete += () => switchLineInProgress = false;
            }
        }

        bool CanSwitchLine(int newIndex)
        {
            bool newIndexValid = newIndex >= 0 && newIndex <= maxLineIndex;

            return !switchLineInProgress && newIndexValid && cat.IsAlive;
        }

        void OnCatDead()
        {
            currentTween.Kill();
        }
    }
}