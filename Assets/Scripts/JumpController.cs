using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpController : MonoBehaviour
{
    //sets an instance for a rigidbody2d
    Rigidbody2D rb;

    //creates a field for you to adjust the jumppower in unity
    [SerializeField] int jumpPower;

    //creates variables to check if the player is on the ground
    public Transform groundCheck;
    public LayerMask groundLayer;
    [SerializeField] bool isGrounded;

    //creates varibles to check if the player is out of bounds
    public Transform fallCheck;
    public LayerMask fallLayer;
    Vector3 startPos;
    [SerializeField] bool isFallen;


    // Start is called before the first frame update
    void Start()
    {
        //gets rigid body for player
        rb = GetComponent<Rigidbody2D>();
        //stores where the player is initially spawned
        startPos = rb.position;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.position);
        //checks if the player is on the layer called ground via a capsle collider
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.1384616f, 0.01901935f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        //checks if the player has fallen out of bounds
        isFallen = Physics2D.OverlapCapsule(fallCheck.position, new Vector2(0.1384616f, 0.01901935f), CapsuleDirection2D.Horizontal, 0, fallLayer);

        //if input is w and the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            //applies jumpPower to the player and lets them jump
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }


    }
    private void FixedUpdate()
    {


        //if the charcter has fallen out of bounds
        if (isFallen)
        {
            //lose 1 life
            gameManager.lives--;

            //if 0 lives
            if (gameManager.lives <= 0)
            {
                //sends player to death scene
                SceneManager.LoadScene("Death");

            }

            //restart level
            rb.position = startPos;


            
            

        }
    }
}
