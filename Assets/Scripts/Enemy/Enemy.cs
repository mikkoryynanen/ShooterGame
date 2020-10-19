
using UnityEngine;

public class Enemy : BaseMoveable
{
    public int health = 5;

    private void Awake()
    {
        Transform = this.transform;
        Position = this.transform.position;
    }

    void Update()
    {
        UpdatePosition(Vector2.left);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogFormat("{0} collided with {1}", this.gameObject.name, collision.gameObject.name);
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (health > 0)
            {
                health--;
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
