using UnityEngine;

public class Wyvern : Boss, IShootable, ISlashable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    [field: SerializeField] public GameObject SlashEffect { get; set; }
    [field: SerializeField] public Transform SlashPoint { get; set; }
    public float SlashTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
        base.InitializeBoss(100, 35, 5, 1.5f, 10, 50, 5, 3, 30);
        rb = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<Hero>();

        ReloadTime = AtkCD;
        SlashTime = AtkCD;

        WaitTime = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        Behavior();
        
        if (anim)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        }
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    public override void AttackType(int currentPhase)
    {
        if (currentPhase == 1)
        {
            Shoot();
            print(this.name + "Shoot");
        }
        else if (currentPhase == 2)
        {
            Slash();
            print(this.name + "Slash");
        }
        else
        {
            print(this.name + "error Boss Attack");
        }
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            if (anim) anim.SetTrigger("Attack");
            
            Vector2 dir = (target.transform.position - transform.position).normalized;

            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Fireballs fireballs = bullet.GetComponent<Fireballs>();
            if (fireballs)
            {
                fireballs.InitProjectile(20, this);
                fireballs.SetDirection(dir);
            }

            WaitTime = 0.0f;

        }
    }

    public void Slash()
    {
        if (WaitTime >= SlashTime)
        {
            if (anim) anim.SetTrigger("Attack");
            
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

                    float scaleX = hitbox.size.x / worldWidth;
                    float scaleY = hitbox.size.y / worldHeight;

                    float value = SlashPoint.position.x - SlashPoint.parent.position.x;
                    if (value < 0) scaleX *= -1;

                    slash.transform.localScale = new Vector3(scaleX, scaleY, 1f);
                }

                Destroy(slash, 0.3f);
            }

            Collider2D[] hits = Physics2D.OverlapBoxAll
            (
                SlashPoint.position,
                SlashPoint.GetComponent<BoxCollider2D>().size, 0

            );

            foreach (var hit in hits)
            {
                Hero heroTarget = hit.GetComponent<Hero>();
                if (heroTarget)
                {
                    heroTarget.TakeDamage(this);
                }
            }

            WaitTime = 0.0f;
        }
    }
}
