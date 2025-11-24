using UnityEngine;

public abstract class Monster : Enemy
{
    
    [field:SerializeField] public Hero target;
    private float lastAttackTime;
    
    public override void Behavior()
    {
        //float distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 distance = transform.position - target.transform.position;

        if (distance.magnitude > AtkRange)
        {
            Chasing(target);
            return;
        }

        //rb.velocity = new Vector2(0, rb.velocity.y);

        if (Time.time - lastAttackTime >= (1f / AtkSpeed))
        {
            AttackType();
            lastAttackTime = Time.time;
        }
        
        
    }

    public override void Chasing(Hero targetHero)
    {
        float direction = Mathf.Sign(targetHero.transform.position.x - transform.position.x);

        rb.linearVelocity = new Vector2(direction * MoveSpeed, rb.linearVelocity.y);

        //transform.localScale = new Vector3(direction, 1, 1);
    }

    public override void CoinDrop()
    {
        throw new System.NotImplementedException();
    }

    public abstract void AttackType();

}
