using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rigid2D;
    Animator animator;
    public GameObject cat;

    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxwalkSpeed = 2.0f;
	// Use this for initialization
	void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.cat = GameObject.Find("cat");
	}
	
	// Update is called once per frame
	void Update () {
        int key = 0;
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        if (Input.GetKey(KeyCode.RightArrow))
            key = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            key = -1;

        if(speedx < this.maxwalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 2.0f;

        if(Input.GetKeyDown(KeyCode.X))
          this.cat.transform.position = new Vector3(0, (float)-4.2, 0);
	}
}
