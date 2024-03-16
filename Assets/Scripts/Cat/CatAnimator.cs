using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    [SerializeField]
    float jumpTime = 1f;
    [SerializeField]
    float punchTime = 0.15f;
    [SerializeField]
    float punchForce = 0.1f;
    [SerializeField]
    Animator animator;

    float originalSpeed;
    Sequence jumpSequence;
    Tween punchTween;

    private void Awake()
    {
        originalSpeed = animator.speed;
    }

    public void PlayPunch()
    {
        if (punchTween.IsActive() && punchTween.IsPlaying())
            return;

        punchTween = transform.DOPunchScale(punchForce * Vector3.one, punchTime, 3);
    }

    public void PlayJump(float jumpHeight)
    {
        if (jumpSequence.IsActive() && jumpSequence.IsPlaying())
            return;
        
        Vector3 jumpDeltaY = new Vector3(0, jumpHeight, 0);

        PlayPunch();        
        jumpSequence = DOTween.Sequence();
        jumpSequence.Append(transform.DOBlendableMoveBy(jumpDeltaY, jumpTime / 2).SetEase(Ease.OutCubic))
            .Append(transform.DOBlendableMoveBy(-jumpDeltaY, jumpTime / 2).SetEase(Ease.InCubic))
            .onComplete += () => PlayPunch();

        jumpSequence.Play();
    }

    public void SetSpeedModifier(float speedModifier)
    {
        animator.speed = originalSpeed * speedModifier;
    }

    public void PlayFall()
    {
        animator.SetTrigger("Fall");
    }
}
