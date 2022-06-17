using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
     MoveObject(GetInput()); 
    }
    private Vector2 GetInput()
    {
        if(Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if(Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST :" + movement);
        rig.velocity = movement;
    }

    public void ActivatePULengthUp(float multiplier)
    {
        transform.localScale = new Vector2(0.5f, 3f * multiplier);
    }

    public void DeactivatePULengthUP(float multiplier)
    {
        transform.localScale = new Vector2(0.5f, 3f);
    }

    public Vector2 ActivatePUSpeedUp(float multiplier)
    {
        Debug.Log("Paddle Speed Up");
        if(Input.GetKey(upKey))
        {
            return Vector2.up * speed * multiplier;
        }
        else if(Input.GetKey(downKey))
        {
            return Vector2.down * speed * multiplier;
        }
        return Vector2.zero;
    }

    public Vector2 DeactivatePUSpeedUp(float multiplier)
    {
        Debug.Log("Paddle Slow Down");
        if(Input.GetKey(upKey))
        {
            return Vector2.up * speed / multiplier;
        }
        else if(Input.GetKey(downKey))
        {
            return Vector2.down * speed / multiplier;
        }
        return Vector2.zero;
        
    }
}
