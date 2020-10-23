using System.Collections;
using UnityEngine;

public abstract class BaseEnemy : BaseMoveable, IDamageable
{
    public int health = 5;

    SpriteRenderer _spriteRenderer;

    public override void Awake()
    {
        base.Awake();

        Transform = this.transform;
        Position = this.transform.position;
        Direction = Vector2.left;

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
    }

    //void Start()
    //{
    //    StartCoroutine(TakeDamageEffectRoutine());
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogFormat("{0} collided with {1}", this.gameObject.name, collision.gameObject.name);
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(1);
            collision.gameObject.SetActive(false);

            
        }
    }

    public void TakeDamage(float amount)
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

    //IEnumerator TakeDamageEffectRoutine()
    //{
    //    Color spriteColor = _spriteRenderer.color;
    //    Color targetColor = Color.black;

    //    float duration = 5.25f;
    //    float timer = 0f;

    //    while (timer < duration)
    //    {
    //        spriteColor = targetColor;

    //        _spriteRenderer.color = Color.Lerp(spriteColor, targetColor, timer / duration);

    //        timer += Time.deltaTime;

    //        yield return null;
    //    }
    //}
}
