
using UnityEngine;

public class Projectile : BaseMoveable
{
    private void Awake()
    {
        Transform = this.transform;
    }

    private void Update()
    {
        UpdatePosition(-Vector2.left);
    }
}
