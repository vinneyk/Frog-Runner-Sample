using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectsScript : MonoBehaviour
{
    public float timer = .25f;

    void Start()
    {
        StartCoroutine(StopEffect());
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
