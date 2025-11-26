using System;
using Unity.Mathematics;
using UnityEngine;

public class Tank : Hero, ISlashable
{
    [field: SerializeField] public GameObject SlashEffect{ get; set; }
    [field: SerializeField] public Transform SlashPoint{ get; set; }

    public float SlashTime { get; set; }
    public float WaitTime { get; set; }

    private float buffDuration;
    private float buffDurationMax;
    private bool onBuff = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        base.InitializeHero(200, 10, 10, 0.6f, 10);

        SkillCD = 10;
        SlashTime = AtkCD;
        WaitTime = 1;

        buffDuration = 0;
        buffDurationMax = 10;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            AttackType();
        }

        if (Input.GetButtonDown("Skill"))
        {
            Skill();
        }

    }
    
    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        SkillWait += Time.fixedDeltaTime;
        SkillWait = Mathf.Clamp(SkillWait, 0.0f, 10.0f);

        buffDuration += Time.fixedDeltaTime;
        buffDuration = Mathf.Clamp(buffDuration, 0.0f, 10.0f);

        checkBuffSkill();

    }

    public void checkBuffSkill()
    {
        if (onBuff)
        {
            if (buffDuration >= buffDurationMax)
            {
                onBuff = false;

                SkillWait = 0.0f;
                buffDuration = 10;
                print("buff end");
            }
        }

    }

    public override void AttackType()
    {
        Slash();
    }

    public override void Skill()
    {
        if ((SkillWait >= SkillCD) && !onBuff)
        {
            buffDuration = 0;
            onBuff = true;

            print("buff start");
        }
    }
    
    public void Slash()
    {
        if (WaitTime >= SlashTime)
        {
            if (SlashEffect)
            {
                GameObject slash = Instantiate(
                    SlashEffect,
                    SlashPoint.position,
                    SlashPoint.rotation
                );

                BoxCollider2D hitbox = SlashPoint.GetComponent<BoxCollider2D>();
                SpriteRenderer sr = slash.GetComponent<SpriteRenderer>();

                if (sr)
                {
                    float worldWidth = sr.sprite.bounds.size.x;
                    float worldHeight = sr.sprite.bounds.size.y;

                    // ปรับ scale ให้ match hitbox
                    float scaleX = hitbox.size.x / worldWidth;
                    float scaleY = hitbox.size.y / worldHeight;

                    float value = SlashPoint.position.x - SlashPoint.parent.position.x;
                    if (value < 0) scaleX *= -1;

                    slash.transform.localScale = new Vector3(scaleX, scaleY, 1f);
                }

                Destroy(slash, 0.1f);
            }

            //Vector2 boxSize = new Vector2(AtkRange, AtkRange * 0.6f); 

            Collider2D[] hits = Physics2D.OverlapBoxAll
            (
                SlashPoint.position,                       // จุดกลาง collider
                SlashPoint.GetComponent<BoxCollider2D>().size, 0 // ขนาด collider

            );

            foreach (var hit in hits)
            {
                Enemy enemyTarget = hit.GetComponent<Enemy>();
                if (enemyTarget)
                {
                    enemyTarget.TakeDamage(this);
                }
            }

            WaitTime = 0.0f;
        }
    }

    public override void TakeDamage(Character other)
    {
        base.TakeDamage(other);
        print("take current " + Hp);
        if (onBuff) 
        {
            Hp += 5;
            print("heal" + Hp);
        }
    }

    public override void TakeDamage(Projectile projectile)
    {
        base.TakeDamage(projectile);
        print("take current " + Hp);
        if (onBuff)
        {
            Hp += 7;
            print("heal" + Hp);
        }

    }

}
