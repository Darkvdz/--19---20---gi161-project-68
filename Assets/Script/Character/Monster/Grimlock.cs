using UnityEngine;

public class Grimlock : Boss, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeBoss(150, 25, 3, 0.8f, 3, 50, 3, 8, 60);
        rb = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        Behavior();
    }

    public override void AttackType(int currentPhase)
    {
        if (currentPhase == 1) 
        {
            print(this.name + "Attack");
        }
        else if (currentPhase == 2)
        {
            //Shoot();
            print(this.name + "Shoot");
        }
        else 
        {
            print(this.name + "error Boss Attack");
        }

    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}
