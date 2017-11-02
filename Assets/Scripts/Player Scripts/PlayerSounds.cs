using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public float audioFootVolume = 1f;
    public float soundEffectPitchRandomness = 0.05f;
    public AudioClip genericFootSound;
    public AudioClip metalFoodSound;

    private AudioSource audioSource;
    private float collisionSoundEffect = 1f;
    
	void Awake () {
        audioSource = GetComponent<AudioSource>();
	}

    void PlayFootSound()
    {
        audioSource.volume = collisionSoundEffect * audioFootVolume;
        audioSource.pitch = Random.Range(1f - soundEffectPitchRandomness, 1f + soundEffectPitchRandomness);

        audioSource.clip = Random.Range(0, 2) > 0 ? genericFootSound : metalFoodSound;
        //audioSource.Play();
    }
	
}
