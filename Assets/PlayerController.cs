using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    public float jumpforce;

    public float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private int health;
    public int healthValue;



    public KeyCode jumpKey;

    private bool isGrounded;

    private int doubleJump;
    public int doubleJumpValue;
     
    
    

    


	// Use this for initialization
	void Start () {
      
        rb = GetComponent<Rigidbody2D>();
        doubleJump = doubleJumpValue;
        health = healthValue;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) {
            Flip();
        }
        
	}

    void Update() {
        
        
        
        if ((Input.GetKeyDown(jumpKey)) && (isGrounded == true)) {

            if (doubleJump > 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpforce, 0);
                isGrounded = true;
                doubleJump--;
                


            }

        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0) {
            isGrounded = true;
            Reset();
            
        }
     
    }
    
    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Reset() {
        doubleJump = doubleJumpValue;
        //isGrounded = true;
    }

    void OnTriggerEnter(Collider2D col) {
        if (col.tag == "spikes") {
            Debug.Log("hello");
            Destroy(col.gameObject);
                
            
        }
    }


}
