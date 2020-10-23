using System;
using UnityEngine;

public abstract class BaseMoveable : MonoBehaviour, IMoveable
{
    [SerializeField] float _speed = 15;
    public float Speed
    {
        get
        {
            return _speed;
        }
    }

    public Transform Transform { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Direction { get; set; }
    public Camera Camera { get; set; }
    
    public virtual void Awake()
    {
        Transform = this.transform;        
    }

    public virtual void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        //Position += newPosition * Speed * Time.deltaTime;
        transform.position += new Vector3(Direction.x * Speed * Time.deltaTime, Direction.y * Speed * Time.deltaTime);

        ClampMovement();
    }

    public void ClampMovement()
    {
        if (Camera == null)
        {
            return;
        }

        Vector3 pos = Camera.WorldToViewportPoint(Position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        Position = Camera.ViewportToWorldPoint(pos);
    }

    protected void ResetPosition()
    {
        Position = Vector2.zero;
        Transform.position = Position;
    }
}
