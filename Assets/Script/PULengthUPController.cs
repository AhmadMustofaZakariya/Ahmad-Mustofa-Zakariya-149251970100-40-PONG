using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULengthUPController : MonoBehaviour
{
    public PowerUpManager manager;
    public Transform ballTag;
    public Collider2D ball;
    public Collider2D paddleRight;
    public Collider2D paddleLeft;
    public float duration;
    public float multiplier;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision == (ballTag.gameObject.tag == "RightBall"))
        {
            StartCoroutine ( RightPaddle() );
        } else if (collision == (ballTag.gameObject.tag == "LeftBall"))
        {
            StartCoroutine ( LeftPaddle() );
        }
        return;
    }

    IEnumerator RightPaddle()
    {
        paddleRight.GetComponent<PaddleController>().ActivatePULengthUp(multiplier);
        
        yield return new WaitForSeconds(duration);
        paddleRight.GetComponent<PaddleController>().DeactivatePULengthUP(multiplier);
        manager.RemovePowerUp(gameObject);
    }

    IEnumerator LeftPaddle()
    {
        paddleLeft.GetComponent<PaddleController>().ActivatePULengthUp(multiplier);
        
        yield return new WaitForSeconds(duration);
        paddleLeft.GetComponent<PaddleController>().DeactivatePULengthUP(multiplier);
        manager.RemovePowerUp(gameObject);
    }
}
