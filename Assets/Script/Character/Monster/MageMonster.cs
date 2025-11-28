using UnityEngine;

public class MageMonster : Monster, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }   
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim=GetComponentInChildren<Animator>();
        base.InitializeEnemy(15, 7, 1, 1.5f, 8, 10, 5);
        rb = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<Hero>();
        
        ReloadTime = AtkCD;
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

    public override void AttackType()
    {
        //Debug.Log("ATK Mage");
        Shoot();
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime) 
        {
            if (anim)
            {
                anim.SetTrigger("Attack");
            }
            
            Vector2 dir = (target.transform.position - transform.position).normalized;
            
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Fireballs fireballs = bullet.GetComponent<Fireballs>();
            if (fireballs) 
            {
                fireballs.InitProjectile(Damage, this);
                fireballs.SetDirection(dir);
            }
            
            WaitTime = 0.0f;

        }
    }
}
