using UnityEngine;

public class MeleeMonster : Monster, ISlashable
{
    [field: SerializeField] public GameObject SlashEffect { get; set; }
    [field: SerializeField] public Transform SlashPoint { get; set; }
    public float SlashTime { get; set; }
    public float WaitTime { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeEnemy(50, 10, 3, 5, 2, 10, 7);
        rb = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<Hero>();

        SlashTime = AtkCD;
        WaitTime = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        Behavior();
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }


    public override void AttackType()
    {
        Slash();
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

                Destroy(slash, 0.3f);
            }

            //Vector2 boxSize = new Vector2(AtkRange, AtkRange * 0.6f); 

            Collider2D[] hits = Physics2D.OverlapBoxAll
            (
                SlashPoint.position,                       // จุดกลาง collider
                SlashPoint.GetComponent<BoxCollider2D>().size, 0 // ขนาด collider

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
