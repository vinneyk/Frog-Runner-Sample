using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDamageShoot : MonoBehaviour
{
    [SerializeField]
    private Transform playerBullet;
    [SerializeField]
    private bool invincible;

    private float distanceBeforeNewPlatforms = 120f;
    //private LevelGenerator levelGenerator;
    private LevelGeneratorPooling levelGenerator;
    private Transform playerTransform;
    public bool canShoot;

	// Use this for initialization
	void Awake () {
        levelGenerator = GameObject.Find(GameObjects.LEVEL_GENERATOR).GetComponent<LevelGeneratorPooling>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
	}

    private void FixedUpdate()
    {
        Fire();
    }

    void OnTriggerEnter(Collider target)
    {
        switch(target.tag)
        {
            case Tags.MORE_PLATFORMS_TAG: 
                Vector3 temp = target.transform.position;
                temp.x += distanceBeforeNewPlatforms;
                target.transform.position = temp;
                levelGenerator.ExtendPlatforms();
                break;
            case Tags.MONSTER_TAG:
            case Tags.MONSTER_BULLET_TAG:
            case Tags.BOUNDS_TAG:
                Die();
                break;
            case Tags.HEALTH_TAG:
                // todo: inform game controller of health collection
                target.gameObject.SetActive(false);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Tags.MONSTER_TAG)
        {
            Die();
        }
    }

    private void Fire()
    {
        if(!canShoot) { return; }

        if(Input.GetKeyDown(KeyCode.K))
        {
            var bulletPos = transform.position;
            bulletPos.y += 1.5f;
            bulletPos.x += 1f;
            var newBullet = Instantiate(playerBullet, bulletPos, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
            newBullet.parent = transform;
        }
    }

    private void Die()
    {
        if (!invincible)
        {
            // todo: inform game controller
            Destroy(gameObject);
        }
    }
}
