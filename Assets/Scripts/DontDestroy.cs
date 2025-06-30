using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public int BgmLevelNum;


    void Start()
    {
        //don't destroy the gameObject which is attached to the 
        DontDestroyOnLoad(this.gameObject);
    }

}
