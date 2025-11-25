using UnityEngine;

public class MageMonster : Monster, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }   
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeEnemy(25, 15, 3, 0.6f, 8, 10, 5);
        rb = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<Hero>();
        
        ReloadTime = AtkCD;
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
        //Debug.Log("ATK Mage");
        Shoot();
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime) 
        {
            Vector2 dir = (target.transform.position - transform.position).normalized;
            
            var bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            Fireballs fireballs = bullet.GetComponent<Fireballs>();
            if (fireballs) 
            {
                fireballs.InitProjectile(20, this);
                fireballs.SetDirection(dir);
            }
            
            WaitTime = 0.0f;

        }
    }
}
