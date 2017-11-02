using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool Jetpacks;
    public float movementSpeed = 5f;
    public float jumpPower = 500f;
    public float secondJumpPower = 400f;
    public Transform groundCheckPosition;
    public float radius = 0.2f;
    public LayerMask layerGround;
    public GameObject smokePosition; 

    private Rigidbody playerBody;
    private bool isGrounded;
    private bool playerJumped;
    private bool canDoubleJump;
    private bool gameStarted;
    private PlayerAnimation playerAnimation;
    private BackgroundScroller backgroundScroller;
    private PlayerHealthDamageShoot playerHealthDamageShoot;

    public bool CanJump {
        get
        {
            return isGrounded || canDoubleJump;
        }
    }

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<PlayerAnimation>();
        backgroundScroller = GameObject.Find(GameObjects.BACKGROUND).GetComponent<BackgroundScroller>();
        playerHealthDamageShoot = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).GetComponent<PlayerHealthDamageShoot>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(StartGame());
	}
	
    private void FixedUpdate()
    {
        if(gameStarted)
        {
            PlayerMove();
            if(!PlayerJump())
            {
                PlayerGrounded();
            }
        }
    }

    private bool PlayerJump()
    {
        if((Jetpacks || isGrounded || canDoubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.LogFormat("Jumped");
            //Debug.Log("Jump: Grounded = {" + isGrounded + "}, canDoubleJump = {" + canDoubleJump + "}");
            playerBody.AddForce(new Vector3(0, (isGrounded ? jumpPower : secondJumpPower), 0));
            playerJumped = true;
            playerAnimation.DidJump();
            canDoubleJump = isGrounded;
            return true;
        }

        return false;
    }

    void PlayerMove()
    {
        playerBody.velocity = new Vector3(movementSpeed, playerBody.velocity.y, 0f);
    }

    void PlayerGrounded()
    {
        //Debug.Log(isGrounded ? "Grounded" : "In air");
        // I think this animation is being triggered immediately after the jump occurred
        isGrounded = Physics.OverlapSphere(groundCheckPosition.position, radius, layerGround).Length > 0;
        if( isGrounded && playerJumped )
        {
            //Debug.LogFormat("Landed");
            playerJumped = false;
            playerAnimation.DidLand();
        }
    }


    IEnumerator StartGame ()
    {
        yield return new WaitForSeconds(2f);
        gameStarted = true;
        smokePosition.SetActive(true);

        // todo: encapsulate the "activated" states within the class and start with method call (interface implementation?)
        backgroundScroller.canScroll = true;
        playerHealthDamageShoot.canShoot = true;
        playerAnimation.PlayerRun();
    }
}
