﻿using UnityEngine;

public class SimpleFootstep : MonoBehaviour
{
    [SerializeField]
    private AudioClip LandingAudioClip;
    [SerializeField]
    private AudioClip[] FootstepAudioClips;
    [SerializeField]
    [Range(0, 1)] private float FootstepAudioVolume = 0.5f;
    [SerializeField]
    private Transform audioPosition;

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(audioPosition.position), FootstepAudioVolume);
            }
        }
    }
    private void OnLand(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(audioPosition.position), FootstepAudioVolume);
        }
    }
}
