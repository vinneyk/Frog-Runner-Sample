using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamageShoot : MonoBehaviour
{
    private float distanceBeforeNewPlatforms = 120f;
    private LevelGenerator levelGenerator;

	// Use this for initialization
	void Awake () {
        levelGenerator = GameObject.Find(GameObjects.LEVEL_GENERATOR).GetComponent<LevelGenerator>();
	}
	
	void OnTriggerEnter(Collider target)
    {
        if (target.tag != "Untagged")
        {
            Debug.LogFormat("Hit: {0}", target.tag);
        }

        if (target.tag == Tags.MORE_PLATFORMS_TAG)
        {
            Vector3 temp = target.transform.position;
            temp.x += distanceBeforeNewPlatforms;
            target.transform.position = temp;

            levelGenerator.GeneratePlatforms();
        }
    }
}
