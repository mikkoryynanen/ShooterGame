using System;
using UnityEngine;

public abstract class BaseControllable : BaseMoveable, IControllable
{
    public void UpdateInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            UpdatePosition(new Vector3(Speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            UpdatePosition(new Vector3(-Speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            UpdatePosition(new Vector3(0, Speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            UpdatePosition(new Vector3(0, -Speed * Time.deltaTime));
        }
    }
}
