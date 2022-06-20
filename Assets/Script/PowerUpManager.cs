using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    private int multiplier2;    
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax; 
    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList; 
    private float timer, timerPULenghtRight, timerPULenghtLeft, timerPUSpeedRight, timerPUSpeedLeft, multiplier;
    public bool isPULengtRight, isPULengtLeft, isPUSpeedRight, isPUSpeedLeft;
    public GameObject paddleRight, paddleLeft; 
    private void Start() 
    { 
        powerUpList = new List<GameObject>();
        timer = 0; 
    }
    private void Update() 
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
        if (isPULengtRight)
        {
            if(timerPULenghtRight > 5)
            {
                paddleRight.GetComponent<PaddleController>().DeactivatePULengthUp(2);
                isPULengtRight = false;
                timerPULenghtRight -= 5;
            }
            timerPULenghtRight += Time.deltaTime;
        }

        if (isPULengtLeft)
        {
            if(timerPULenghtLeft > 5)
            {
                paddleLeft.GetComponent<PaddleController>().DeactivatePULengthUp(2);
                isPULengtLeft = false;
                timerPULenghtLeft -= 5;
            }
            timerPULenghtLeft += Time.deltaTime;
            Debug.Log(timerPULenghtLeft); 
        }

        if (isPUSpeedRight)
        {
            if(timerPUSpeedRight > 5)
            {
                paddleRight.GetComponent<PaddleController>().DeactivatePUSpeedUp(2);
                isPUSpeedRight = false;
                timerPUSpeedRight -= 5;
            }
            timerPUSpeedRight += Time.deltaTime;
        }
        
        if (isPUSpeedLeft)
        {
            if(timerPUSpeedLeft > 5)
            {
                paddleLeft.GetComponent<PaddleController>().DeactivatePUSpeedUp(multiplier2);
                isPUSpeedLeft = false;
                timerPUSpeedLeft -= 5;
            }
            timerPUSpeedLeft += Time.deltaTime;
        }


    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    } 

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if(powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if(position.x < powerUpAreaMin.x ||position.x > powerUpAreaMax.x||position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex],new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp); 
    }
    
    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
