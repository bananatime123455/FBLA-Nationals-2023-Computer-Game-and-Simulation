using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    [SerializeField] private int levelNum;
    //sets varibles to show score in game
    [SerializeField] private int currentScore;
    [SerializeField]  TextMeshProUGUI scoreText;

    //text to show lives 
    [SerializeField] TextMeshProUGUI livesText;

    //sets global variables
    public static gameManager Instance { get; private set; }
    public static int score = 0;
    public static int lives = 3;

    private void Start()
    {

        //don't destroy any bmgs which are labled as don't destroy
        DontDestroy[] bgms = FindObjectsOfType<DontDestroy>();
        //for all the bgms which shouldn't be destroyed
        foreach (DontDestroy bgm in bgms)
        {
            //check if the bgm isn't for the level 
            if(bgm.BgmLevelNum != levelNum)
            {
                //if the bgm isn't for the level then destroy it
                Destroy(bgm.gameObject);
            }
        }
    }

    //checks to see if the user has press escape every frame
    void Update()
    {

        //makes sure lives = 3 in tutorial
        if (levelNum == 0) 
        {
            resetGame();
        }

        //if escape is pressed, quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed");
            Application.Quit();
        }
        //sets the displayed score to the score in the gameManager
        scoreText.text = ("Score: " + score.ToString());
        livesText.text = ("Lives: " + lives.ToString());

    }

    //resets the game
    public void resetGame()
    { 
        //resets number of lives
        lives = 3;
        score = 0;
    }

}
