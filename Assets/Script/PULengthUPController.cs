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
    public float duration, multiplier; 
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
            RightPUActive();
            manager.isPULengtRight = true;
            manager.RemovePowerUp(gameObject);

        } else if (collision == (ballTag.gameObject.tag == "LeftBall"))
        {
            LeftPUActive();
            manager.isPULengtLeft = true;
            manager.RemovePowerUp(gameObject);
        }
        return;
    }

    public void RightPUActive()
    {   
        paddleRight.GetComponent<PaddleController>().ActivatePULengthUp(multiplier);
    }
    public void LeftPUActive()
    {   
        paddleLeft.GetComponent<PaddleController>().ActivatePULengthUp(multiplier);
    }

    IEnumerator RightPaddle()
    {
        paddleRight.GetComponent<PaddleController>().ActivatePULengthUp(multiplier);
        yield return new WaitForSeconds(duration);
        paddleRight.GetComponent<PaddleController>().DeactivatePULengthUp(multiplier);
        manager.RemovePowerUp(gameObject);
    }

    IEnumerator LeftPaddle()
    {
        paddleLeft.GetComponent<PaddleController>().ActivatePULengthUp(multiplier);
        yield return new WaitForSeconds(duration);
        paddleLeft.GetComponent<PaddleController>().DeactivatePULengthUp(multiplier);
        manager.RemovePowerUp(gameObject);
    }
}
