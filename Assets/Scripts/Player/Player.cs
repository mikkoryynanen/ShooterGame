using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillsManager))]
public class Player : BaseControllable, IShootable
{
    public GameObject bulletPrefab;
    public float fireRate = .1f;

    SkillsManager _skillsManager;
    
    void Start()
    {
        Camera = Camera.main;
        _skillsManager = GetComponent<SkillsManager>();
        _skillsManager.Init();

        ObjectPooler.Add<Projectile>(bulletPrefab, 50);

        StartCoroutine(ShootingSequence());
    }
        
    public override void Update()
    {
        base.Update();
        UpdateInput();
    }

    public IEnumerator ShootingSequence()
    {
        //YieldInstruction yi = ;
        while (true)
        {
            Projectile b = ObjectPooler.Get<Projectile>();
            b.transform.position = this.transform.position;

            // TODO cache this in the future? this is for debugging
            yield return new WaitForSeconds(fireRate);
        }
    }
}
