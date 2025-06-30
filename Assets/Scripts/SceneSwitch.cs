using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //creates a string for which scene to switch to
    public string scene;

    //switch to a specified scene if gameobject is collided with
    private void OnTriggerEnter2D(Collider2D other)
    {
        //loads specified scene
        SceneManager.LoadScene(scene);

    }

    //for button clicks

    //switch to input scene
    public void sceneSwitchToInput()
    {
        SceneManager.LoadScene(GlobalSetting.Input);
    }

    //switch to first scene
    public void sceneSwitchTo1()
    {
        SceneManager.LoadScene(GlobalSetting.ToLevelOne);
    }


    //switch to victory scene
    public void sceneChangeToVictory()
    {
        SceneManager.LoadScene(GlobalSetting.VictoryScene);
    }

    //switch to death scene
    public void sceneChangeToDeath()
    {
        SceneManager.LoadScene(GlobalSetting.Death);
    }

    //switch to story0 scene
    public void sceneChangeToStory0()
    {
        SceneManager.LoadScene(GlobalSetting.Story0);
    }

    //switch to scene called HomeBase
    public void sceneChangeToStart()
    {
        SceneManager.LoadScene(GlobalSetting.Homebase);
    }
    //switch to scene called Instructions1
    public void sceneChangeToInstructions1()
    {
        SceneManager.LoadScene(GlobalSetting.Instructions1);
    }
    //switch to scene called Instructions2
    public void sceneChangeToInstructions2()
    {
        SceneManager.LoadScene(GlobalSetting.Instructions2);
    }

    //switch to scene called Instructions3
    public void sceneChangeToInstructions3() 
    {
        SceneManager.LoadScene(GlobalSetting.Instructions3);
    }
    //switch to scene called Instructions4
    public void sceneChangeToInstructions4()
    {
        SceneManager.LoadScene(GlobalSetting.Instructions4);
    }
    //switch to scene called Menu
    public void sceneChangeToTitle()
    {
        SceneManager.LoadScene(GlobalSetting.MainMenu);
    }
    //switch to scene called HighScores
    public void sceneChangeToScore()
    {
        SceneManager.LoadScene(GlobalSetting.HighScores);
    }
    public void sceneChangeToTutorial() 
    {
        SceneManager.LoadScene(GlobalSetting.Tutorial);
    }


    //quits the game 
    public void endGame()
    {
        Application.Quit();
    }

}
