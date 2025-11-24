using UnityEngine;

public class MeleeMonster : Monster
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeEnemy(50, 10, 3, 5, 0, 10, 7);
        print(target);
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
        Debug.Log("ATK MEELEE");
    }
}
