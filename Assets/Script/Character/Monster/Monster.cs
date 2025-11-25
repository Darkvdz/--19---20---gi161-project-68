using UnityEngine;

public abstract class Monster : Enemy
{
    
    public override void Behavior()
    {
        //float distance = Vector2.Distance(transform.position, target.transform.position);
        Vector2 distance = transform.position - target.transform.position;

        if (distance.magnitude > AtkRange)
        {
            Chasing(target);
            return;
        }
        else
        {
            //rb.velocity = new Vector2(0, rb.velocity.y);
            if (Time.time - lastAttackTime >= (1f / AtkCD))
            {
                AttackType();
                lastAttackTime = Time.time;
            } 
        }
    }

    public override void Chasing(Hero targetHero)
    {
        float direction = Mathf.Sign(targetHero.transform.position.x - transform.position.x);

        rb.linearVelocity = new Vector2(direction * MoveSpeed, rb.linearVelocity.y);

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction; 
        transform.localScale = scale;
    }

    public override void CoinDrop()
    {
        GameManager.Instance.MonsterKilled(this.gameObject);
    }

    public abstract void AttackType();

}
