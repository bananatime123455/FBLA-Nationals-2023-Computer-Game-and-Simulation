using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    bool isMove;
    void Start()
    {
        //gets animator compenent from player
        playerAnimator = GetComponent<Animator>();
        if (playerAnimator == null)
        {
            //if not there display error
            Debug.LogError("No Animator On Player !");
        }
        //player is not moving
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if player moves
        if (!isMove && Input.GetAxis("Horizontal") != 0)
        {
            //player is considered moving
            isMove = true;
            //sets animation to isWalk
            playerAnimator.SetBool("isWalk", true);
        }
        //if player is no longer moving
        else if(isMove && Input.GetAxis("Horizontal") == 0)
        {
            //player is considered not moving
            isMove = false;
            //no longer displays isWalk animation
            playerAnimator.SetBool("isWalk", false);
        }

        //don't destroy any bmgs which are labled as don't destroy
        DontDestroy[] bgms = FindObjectsOfType<DontDestroy>();
        //for all the bgms which shouldn't be destroyed
        foreach (DontDestroy bgm in bgms)
        {
            //if level is the victory scene
            if (bgm.BgmLevelNum == GlobalSetting.HomeLevelBgmNum) 
            {
                //displays the player idle animation
                playerAnimator.SetBool("homeIdle", true);
            }

            //if level is no longer the victory scene
            if (bgm.BgmLevelNum != 64)
            {
                //no longer displays the player idle animation
                playerAnimator.SetBool("homeIdle", false);
            }

        }
    }


}
