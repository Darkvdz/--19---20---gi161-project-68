using UnityEngine;

public abstract class Enemy : Character
{
    public int Coin { get; set; }

    public int ChasingSpeed { get; set; }

    [field: SerializeField] public Hero target;
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

    public abstract void Behavior();
    public abstract void CoinDrop();
    public abstract void Chasing(Hero targetHero);

}
