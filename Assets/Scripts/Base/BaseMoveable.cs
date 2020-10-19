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
    public Camera Camera { get; set; }

    public void UpdatePosition(Vector2 newPosition)
    {
        Position += newPosition * Speed * Time.deltaTime;
        Transform.position = Position;

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
}
