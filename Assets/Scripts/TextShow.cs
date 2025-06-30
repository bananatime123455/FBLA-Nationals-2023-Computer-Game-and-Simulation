using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextShow : MonoBehaviour
{
    public GameObject text;
    

    void Start()
    {
        // makes the text not show initally
        text.SetActive(false); 

    }


    // on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object collides with player 
        if (collision.gameObject.tag == "Player")
        {
            //Make your text object appear on screen
            text.SetActive(true);

        }
    }


    //when exit collision
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if object collides with player
        if (collision.gameObject.tag == "Player")
        {
            //Make your text object disappear on the screen
            text.SetActive(false);


        }
    }

}
