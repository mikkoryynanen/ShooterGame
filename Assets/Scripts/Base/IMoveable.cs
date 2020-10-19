using UnityEngine;

interface IMoveable
{ 
    void UpdatePosition(Vector2 newPosition);
    void ClampMovement();
}