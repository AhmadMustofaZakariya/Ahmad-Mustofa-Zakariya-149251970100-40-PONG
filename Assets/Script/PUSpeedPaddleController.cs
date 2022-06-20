using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Transform ballTag;
    public Collider2D ball;
    public Collider2D paddleRight;
    public Collider2D paddleLeft;
    public float duration;
    public int multiplier2;
    private float timer;
    public int spawnInterval;

    private void Update() 
    {
        timer += Time.deltaTime;
        if(timer > spawnInterval)
        {
            manager.RemovePowerUp(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision == (ballTag.gameObject.tag == "RightBall"))
        {
            paddleRight.GetComponent<PaddleController>().ActivatePUSpeedUp(multiplier2);
            manager.isPUSpeedRight = true;
            manager.RemovePowerUp(gameObject);

        } else if (collision == (ballTag.gameObject.tag == "LeftBall"))
        {
            paddleLeft.GetComponent<PaddleController>().ActivatePUSpeedUp(multiplier2);
            manager.isPUSpeedLeft = true;
            manager.RemovePowerUp(gameObject);
        }
        return;
    }


    /* IEnumerator RightPaddle()
    {
        paddleRight.GetComponent<PaddleController>().ActivatePUSpeedUp(multiplier);
        yield return new WaitForSeconds(duration);
        paddleRight.GetComponent<PaddleController>().DeactivatePUSpeedUp(multiplier);
        manager.RemovePowerUp(gameObject);
    }

    IEnumerator LeftPaddle()
    {
        paddleLeft.GetComponent<PaddleController>().ActivatePUSpeedUp(multiplier);
        yield return new WaitForSeconds(duration);
        paddleLeft.GetComponent<PaddleController>().DeactivatePUSpeedUp(multiplier);
        manager.RemovePowerUp(gameObject);
    }*/
}
