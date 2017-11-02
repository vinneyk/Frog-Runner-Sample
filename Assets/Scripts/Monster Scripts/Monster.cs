using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject MonsterDiedEffect;
    public Transform bullet;
    public float distanceFromPlayerToStartMove = 20f;
    public float movementSpeed_min = 1f;
    public float movementSpeed_max = 1f;

    private bool moveRight;
    private float movementSpeed;
    private bool isPlayerInRegion;

    private Transform playerTransform;
    public bool canShoot;

    // Use this for initialization
    void Start () {
        canShoot = Random.Range(0.0f, 1.0f) > .5f;
        movementSpeed = Random.Range(movementSpeed_min, movementSpeed_max);
        playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }
	
	// Update is called once per frame
	void Update () {
		if(playerTransform)
        {
            var distance = (playerTransform.position - transform.position).magnitude;
            if(distance < distanceFromPlayerToStartMove)
            {
                var temp = transform.position;
                var movementDelta = Time.deltaTime * movementSpeed;

                if(!moveRight)
                {
                    movementDelta *= -1;
                } 
                temp.x += movementDelta;
                transform.position = new Vector3(temp.x, transform.position.y, transform.position.z);

                if(!isPlayerInRegion)
                {
                    if(canShoot)
                    {
                        InvokeRepeating("StartShooting", 0.5f, 1.5f);
                        canShoot = false;
                    }
                    isPlayerInRegion = true;
                }
            }
            else
            {
                CancelInvoke("StartShooting");
            }
        }
	}

    void StartShooting()
    {
        if(playerTransform)
        {
            var bulletPos = transform.position;
            bulletPos.y += 1.5f;
            bulletPos.x -= 1;
            var b = Instantiate(bullet, bulletPos, Quaternion.identity);
            b.GetComponent<Rigidbody>().AddForce(transform.forward * 1500f);
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == Tags.PLAYER_BULLET_TAG)
        {
            Death();
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == Tags.PLAYER_TAG)
        {
            Death();
        }
    }

    private void Death()
    {
        var effectPosition = transform.position;
        effectPosition.y += 2f;
        Instantiate(MonsterDiedEffect, effectPosition, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
