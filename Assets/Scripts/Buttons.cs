using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void Update()
    {
        //makes it so that player can return to tutorial
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene("HomeBase");
            //don't destroy any bmgs which are labled as don't destroy
            DontDestroy[] bgms = FindObjectsOfType<DontDestroy>();
            //for all the bgms 
            foreach (DontDestroy bgm in bgms)
            {
                //destroy all the bgms
                Destroy(bgm.gameObject);
            }
        }
    }
        
}
