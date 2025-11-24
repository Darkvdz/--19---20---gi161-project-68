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
        base.InitializeEnemy(25, 15, 3, 3, 8, 10, 5);
        rb = GetComponent<Rigidbody2D>();
        target = FindAnyObjectByType<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        Behavior();
    }

    public override void AttackType()
    {
        Debug.Log("ATK Mage");
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }
}
