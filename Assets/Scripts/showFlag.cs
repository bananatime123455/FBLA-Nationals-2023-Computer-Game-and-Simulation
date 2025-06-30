using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class showFlag : MonoBehaviour
{
    public GameObject Flag;

    void Start()
    {
        Flag.SetActive(false);
    }


    // on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object collides with player 
        if (collision.gameObject.tag == "Player")
        {
            Flag.SetActive(true);

        }
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

}
