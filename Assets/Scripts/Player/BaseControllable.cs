using System;
using UnityEngine;

public abstract class BaseControllable : BaseMoveable, IControllable
{
    public void UpdateInput()
    {
        if (Input.anyKey)
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else
        {
            Direction = Vector2.zero;
        }        
    }
}
