using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private void Start()
    {
        
    }

    private void Update()
    {
     MoveObject(GetInput()); 
    }
    private Vector2 GetInput()
    {
        if(Input.GetKey(upKey))
        {
            return Vector2.up *speed;
        }
        else if(Input.GetKey(downKey))
        {
            return Vector2.down *speed;
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        transform.Translate(movement * Time.deltaTime);
    }
}
