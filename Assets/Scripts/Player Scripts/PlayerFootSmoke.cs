﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSmoke : MonoBehaviour
{
    public GameObject smokeEffect;
    public GameObject smokePosition;
    public Transform parent; //todo: organize smoke objects within parent in hierarchy

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == Tags.PLATFORM_TAG)
        {
            if(smokePosition.activeInHierarchy)
            {
                Instantiate(smokeEffect, smokePosition.transform.position, Quaternion.identity);
            }
        }
    }
}
