using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Boss : Enemy
{
    private bool changedStage = false;

    public int AttackRangePhase2 { get; set; }

    public float ChangePhaseAt { get; set; }

    protected int currentPhase = 1;


    public void InitializeBoss(int startHealth, int startDamage, int startMoveSpeed, int startAtkSpeed, int startAtkRange, int startCoin, int startChasingSpeed, int startAttackRangePhase2, float percentChangePhase)
    {
        base.InitializeEnemy(startHealth, startDamage, startMoveSpeed, startAtkSpeed, startAtkRange, startCoin, startChasingSpeed);

        AttackRangePhase2 = startAttackRangePhase2;
        ChangePhaseAt = percentChangePhase;


    }

    public override void Behavior()
    {
        if ((!changedStage) && (Hp <= ChangePhaseAt))
        {
            changedStage = true;
            AtkRange = AttackRangePhase2;
            currentPhase = 2;

        }

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
            if (Time.time - lastAttackTime >= (1f / AtkSpeed))
            {
                AttackType(currentPhase);
                lastAttackTime = Time.time;
            }

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
        OnDeathDrop();
    }
    
    public void OnDeathDrop() 
    {
    
    }

    public abstract void AttackType(int currentPhase);

}
