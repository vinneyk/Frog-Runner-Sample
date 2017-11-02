using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float offsetSpeed = -0.0006f;
    [HideInInspector]
    public bool canScroll = true;

    private Renderer bgRenderer;

    
	void Awake () {
        bgRenderer = GetComponent<MeshRenderer>();
	}
	
	void FixedUpdate () {
        if (canScroll)
        {
            bgRenderer.material.mainTextureOffset -= new Vector2(offsetSpeed, 0);
        }
	}
}
