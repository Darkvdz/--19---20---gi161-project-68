using UnityEngine;

public abstract class Hero : Character
{


    public Item[] ItemEquip { get; set; }

    public void InitializeHero(int startHealth, int startDamage, int startMoveSpeed, float startAtkCD, int startAtkRange)
    {
        base.InitializeCharacter(startHealth, startDamage, startMoveSpeed, startAtkCD, startAtkRange);

    }
    public abstract void AttackType();

    public abstract void Skill();

    public override void OnDeath()
    {
        Destroy(this.gameObject);
    }


}
