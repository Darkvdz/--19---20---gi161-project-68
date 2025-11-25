using UnityEngine;

public class SwordMan : Hero, ISlashable
{
    [field: SerializeField] public GameObject SlashEffect{ get; set; }
    [field: SerializeField] public Transform SlashPoint{ get; set; }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeHero(100, 20, 10, 5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            AttackType();
        }
    }

    public override void AttackType()
    {
        Slash();
    }

    public override void Skill()
    {
        throw new System.NotImplementedException();
    }

   
    public void Slash()
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
                Vector2 spriteSize = sr.bounds.size;
                
                float scaleX = hitbox.size.x / spriteSize.x;
                float scaleY = hitbox.size.y / spriteSize.y;

                slash.transform.localScale = new Vector3(scaleX, scaleY, 1);
            }

            // ทำลายเอฟเฟกต์หลัง 0.3 วินาที (แล้วแต่ภาพคุณ)
            Destroy(slash, 0.3f);
        }
        
        Vector2 boxSize = new Vector2(AtkRange, AtkRange * 0.6f); 
        
        Collider2D[] hits = Physics2D.OverlapBoxAll
        (
            SlashPoint.position,                       // จุดกลาง collider
            SlashPoint.GetComponent<BoxCollider2D>().size,0 // ขนาด collider
            
        );

        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(this);
            }
        }
    }
}
