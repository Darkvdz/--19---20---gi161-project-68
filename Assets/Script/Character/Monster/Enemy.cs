using UnityEngine;

public abstract class Enemy : Character
{
    public int Coin { get; set; }
    public int ChasingSpeed { get; set; }

    [field: SerializeField] public Hero target;
    [field: SerializeField] public Transform hpCanvas;
    
    protected float lastAttackTime;
    
    public void InitializeEnemy(int startHealth, int startDamage, int startMoveSpeed, float startAtkSpeed, int startAtkRange, int startCoin, int startChasingSpeed)
    {
        base.InitializeCharacter(startHealth, startDamage, startMoveSpeed, startAtkSpeed, startAtkRange);

        Coin = startCoin;
        ChasingSpeed = startChasingSpeed;
    }
    
    public override void OnDeath()
    {
        CoinDrop();
        Destroy(this.gameObject);
    }

    public void FaceTarget()
    {

        float direction = Mathf.Sign(target.transform.position.x - transform.position.x);

        Vector3 scale = transform.localScale;

        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;

        if (hpCanvas)
        {
            Vector3 hpScale = hpCanvas.localScale;
            hpScale.x = Mathf.Abs(hpScale.x) * direction;
            hpCanvas.localScale = hpScale;
        }
    }

    public abstract void Behavior();
    public abstract void CoinDrop();
    public abstract void Chasing(Hero targetHero);

}
