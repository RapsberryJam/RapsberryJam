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

        void Awake()
        {
            maxLineIndex = linePositions.Count - 1;
            currentLineIndex = linePositions.Count / 2;
            switchingAvailable = true;
        }

        public void SwitchLine(Direction direction)
        {
            int newLineIndex = direction == Direction.Left
                ? currentLineIndex - 1
                : currentLineIndex + 1;

            if (CanSwitchLine(newLineIndex))
            {
                currentLineIndex = newLineIndex;
                switchLineInProgress = true;
                cat.transform.DOMove(linePositions[newLineIndex].position, switchingLineDuration)
                    .SetEase(Ease.InQuint)
                    .onComplete += () => switchLineInProgress = false;
            }
        }

        bool CanSwitchLine(int newIndex)
        {
            bool newIndexValid = newIndex >= 0 && newIndex <= maxLineIndex;

            return !switchLineInProgress && newIndexValid;
        }
    }
}