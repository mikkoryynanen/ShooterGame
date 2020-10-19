using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseControllable
{
    public float speed = 100;

    public Player() { }

    public Player(Transform transform, Vector2 initialPosition) : base(transform, initialPosition)
    {               
    }
    
    void Awake()
    {
        Player p = new Player
        {
            Transform = this.transform,
            Position = Vector2.zero
        };
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            UpdatePosition(new Vector3(speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            UpdatePosition(new Vector3(-speed * Time.deltaTime, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            UpdatePosition(new Vector3(0, speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            UpdatePosition(new Vector3(0, -speed * Time.deltaTime));
        }
    }
}
