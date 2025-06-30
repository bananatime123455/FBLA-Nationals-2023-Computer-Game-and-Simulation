using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenGroundShow : MonoBehaviour
{
    //allows for the gameobject which should be shown to be assigned and creates a time to count down from
    [SerializeField] private GameObject[] hiddenBLocks;
    [SerializeField] private float countDownTime = 2f;
    //initalizes a last index and current index to look through a list
    int lastIndex;
    int currentIndex;
    //creats a timer starting at 0 seconds
    [SerializeField] private float timer = 0;
    void Start()
    {
        //for every block in the hiddenblocks game object
        foreach(GameObject block in hiddenBLocks)
        {
            //hide the blocks
            block.GetComponent<SpriteRenderer>().enabled = false;
        }
        //finds a random index in hiddenblocks
        currentIndex = Random.Range(0, hiddenBLocks.Length - 1);
        //keeps track of the last used index by setting it equal to the new current index
        lastIndex = currentIndex;
        //show the block who's index was randomly selected
        hiddenBLocks[currentIndex].GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //start the timer
        timer += Time.deltaTime;
        //if the timer has been running for more than 2 seconds
        if(timer > countDownTime)
        {
            //reset the timer
            timer = 0;
            //hide the block who's index was randomly choosen
            hiddenBLocks[lastIndex].GetComponent<SpriteRenderer>().enabled = false;
            //find a new randomly selected block's index
            currentIndex = Random.Range(0, hiddenBLocks.Length - 1);
            //set last used index to the new randomly selected block's index
            lastIndex = currentIndex;
            //show the new block who's index was selected
            hiddenBLocks[currentIndex].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
