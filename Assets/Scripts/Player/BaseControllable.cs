using UnityEngine;

public abstract class BaseControllable : MonoBehaviour, IControllable
{
    public Transform Transform { get; set; }
    public Vector2 Position { get; set; }

    public BaseControllable() { }

    public BaseControllable(Transform transform, Vector2 initialPosition)
    {
        Transform = transform;
        Position = initialPosition;
    }

    public void UpdatePosition(Vector2 newPosition)
    {
        Position += newPosition;
    }
}
