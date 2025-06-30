using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class camera conflicts with UnityEngine.Camera
// rename it or put it in a namespace
namespace MyGame
{
    public class Camera : MonoBehaviour
    {
        public GameObject player;
        public float offset;

        void Update()
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y + offset);
        }
    }
}
