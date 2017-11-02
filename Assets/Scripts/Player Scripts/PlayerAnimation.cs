using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animation playerAnimation;

	void Awake () {
        playerAnimation = GetComponent<Animation>();
	}

    public void DidJump()
    {
        playerAnimation.Play(Tags.ANIMATION_JUMP);
        playerAnimation.PlayQueued(Tags.ANIMATION_JUMP_FALL);
    }

    public void DidLand()
    {
        playerAnimation.Stop(Tags.ANIMATION_JUMP_FALL);
        playerAnimation.Stop(Tags.ANIMATION_JUMP_LAND);
        playerAnimation.Blend(Tags.ANIMATION_JUMP_LAND, 0);
        playerAnimation.CrossFade(Tags.ANIMATION_RUN);
    }

    public void PlayerRun()
    {
        playerAnimation.Play(Tags.ANIMATION_RUN);
    }
} 
