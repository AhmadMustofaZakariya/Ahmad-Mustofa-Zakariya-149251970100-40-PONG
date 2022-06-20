using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int spawnInterval;
    public float magnitude; 
    private float timer;
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
        if(collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
