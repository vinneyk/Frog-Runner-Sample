using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float LifeTime = 5f;
    private float startY;
    private IEnumerable<string> interactiveTags = new string[]
    {
        Tags.MONSTER_TAG,
        Tags.MONSTER_BULLET_TAG,
        Tags.PLAYER_TAG,
        Tags.PLAYER_BULLET_TAG
    };

	// Use this for initialization
	void Start () {
        startY = transform.position.y;
	}
	
    //After Update
	void LateUpdate () {
        transform.position = new Vector3(transform.position.x, startY, transform.position.z);
	}

    IEnumerator TurnOffBullet()
    {
        yield return new WaitForSeconds(LifeTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider target)
    {
        if(interactiveTags.Contains( target.tag ))
        {
            gameObject.SetActive(false);
        }
        if(target.tag == Tags.PLAYER_TAG)
        {
            // todo: kill player, play death animation, reset game
        }
    }
}
