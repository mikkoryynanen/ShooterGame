using UnityEngine;

public class Projectile : BaseMoveable, ITimeDisableable
{
    float _lifetimeTimer = 0f;


    public override void Awake()
    {
        base.Awake();
        Direction = transform.right;
    }

    public override void Update()
    {
        base.Update();
        DisableTimer();
    }

    public void DisableTimer()
    {
        if (!this.gameObject.activeInHierarchy)
        {
            return;
        }

        if (_lifetimeTimer >= 2)
        {
            ResetPosition();
            _lifetimeTimer = 0f;
            this.gameObject.SetActive(false);
        }
        else
        {
            _lifetimeTimer += Time.deltaTime;
        }
    }
}
