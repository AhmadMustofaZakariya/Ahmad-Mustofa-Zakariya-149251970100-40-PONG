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
        transform.localScale = new Vector2(0.5f, transform.localScale.y * multiplier);
        // tranform.localScale.y += new Vector2.y * multiplier;
    }

    public void DeactivatePULengthUp(float multiplier)
    {
        transform.localScale = new Vector2(0.5f, transform.localScale.y / multiplier);
        // tranform.localScale.y += new Vector2.y / multiplier;
    }
    
    public void ActivatePUSpeedUp(int multiplier2)
    {
        Debug.Log("Paddle Speed Up");
        speed *= multiplier2;
    }
    
    public void DeactivatePUSpeedUp(int multiplier2)
    {
        Debug.Log("Paddle Slow Down");
        speed /= multiplier2;
    }
}
