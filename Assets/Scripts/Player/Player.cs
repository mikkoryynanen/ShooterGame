using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseControllable, IShootable
{
    public GameObject bulletPrefab;
    public float fireRate = .1f;

    List<Projectile> _projectiles = new List<Projectile>();
    int _bulletIndex = 0;
    
    void Awake()
    {
        Transform = this.transform;
        Camera = Camera.main;

        for (int i = 0; i < 25; i++)
        {
            Projectile p = Instantiate(bulletPrefab).GetComponent<Projectile>();
            p.gameObject.SetActive(false);
            _projectiles.Add(p);
        }

        StartCoroutine(ShootingSequence());
    }

    void Update()
    {
        UpdateInput();
    }

    public IEnumerator ShootingSequence()
    {

        //YieldInstruction yi = ;
        while (true)
        {
            _projectiles[_bulletIndex].gameObject.SetActive(true);
            _projectiles[_bulletIndex].Position = transform.position;

            if (_bulletIndex >= _projectiles.Count - 1)
                _bulletIndex = 0;
            else
                _bulletIndex++;

            // TODO cache this in the future? this is for debugging
            yield return new WaitForSeconds(fireRate);
        }
    }
}
