using UnityEngine;

public class Markman : Hero, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeHero(100, 20, 10, 2, 10);

        ReloadTime = AtkCD;
        WaitTime = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            AttackType();
        }
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    public override void AttackType()
    {
        Shoot();
    }

    public override void Skill()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        if (WaitTime >= ReloadTime) 
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Arrow arrow = bullet.GetComponent<Arrow>();
            if (arrow) 
            {
                arrow.InitProjectile(20, this);
            }

            WaitTime = 0.0f;

        }
    }

}
