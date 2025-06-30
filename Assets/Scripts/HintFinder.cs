using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HintFinder : MonoBehaviour
{
    public GameObject hiddenText;
    public GameObject hiddenGround;
    public GameObject Flag;

    void Start()
    {
        // makes the hidden Ground exist initally
        hiddenGround.SetActive(true);
        //makes the hidden hint text not appear initally
        hiddenText.SetActive(false);
        //hide flag initially
        Flag.SetActive(true);

    }

    //when exit collision
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if object collides with player
        if (collision.gameObject.tag == "Player")
        {
            //make flag disappear
            Flag.SetActive(false);
        }
    }

    // on collision with the flag
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with flag 
        {
            //if object collides with player 
            if (collision.gameObject.tag == "Player")
            {
                Flag.SetActive(true);

            }
            //Make hint text appear on screen
            hiddenText.SetActive(true);
            //makes the hidden ground disappear
            hiddenGround.SetActive(false);
            //makes the flag disappeaer
            Flag.SetActive(false);
        }
    }
    

}
