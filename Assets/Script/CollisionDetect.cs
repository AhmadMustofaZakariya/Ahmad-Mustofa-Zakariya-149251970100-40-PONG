using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public Collider2D ball;
    public Transform ballTag;
    public void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "PlayerRight")
        {
            ballTag.gameObject.tag = "RightBall";
        } else if (other.gameObject.tag == "PlayerLeft")
        {
            ballTag.gameObject.tag = "LeftBall";
        }
        return;
    }
}
