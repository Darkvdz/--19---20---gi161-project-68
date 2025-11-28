using System;
using System.Collections;
using UnityEngine;

public class Markman : Hero, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Awake()
    {
        
        base.Awake();//for animation
        
        //75/5
        base.InitializeHero(75, 5, 7, 0.5f, 10);


        SkillCD = 10;
        ReloadTime = AtkCD;
        WaitTime = 1;


    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        if (Input.GetButtonDown("Attack"))
        {
            AttackType();
        }

        if (Input.GetButtonDown("Skill"))
        {
            print(SkillWait);
            print(SkillCD);
            print(SkillWait >= SkillCD);
            Skill();
        }

    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        SkillWait += Time.fixedDeltaTime;
        SkillWait = Mathf.Clamp(SkillWait, 0.0f, 10.0f);
    }

    public override void AttackType()
    {
        if (WaitTime >= ReloadTime)
        {
            PlayAttackAnim();
            Shoot();
        }
    }

    public override void Skill()
    {
        if (SkillWait >= SkillCD)
        {
            StartCoroutine(SkillRoutine());
            SkillWait = 0.0f;
        }
    }

    private IEnumerator SkillRoutine()
    {
        for (int i = 0; i < 5; i++)
        {
            Shoot();
            yield return new WaitForSeconds(0.15f);
        }
    }


    public void Shoot()
    {
        var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        Arrow arrow = bullet.GetComponent<Arrow>();
        if (arrow) 
        {
            arrow.InitProjectile(Damage, this);
        }

        WaitTime = 0.0f;

    }

}
