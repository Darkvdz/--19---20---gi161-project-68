using UnityEngine;

public abstract class Hero : Character
{
    public Item[] ItemEquip { get; set; }

    public float SkillCD { get; set; }

    public float SkillWait;

    public void InitializeHero(int startHealth, int startDamage, int startMoveSpeed, float startAtkCD, int startAtkRange)
    {
        base.InitializeCharacter(startHealth, startDamage, startMoveSpeed, startAtkCD, startAtkRange);
        SkillWait = 10f;

    }
    public abstract void AttackType();

    public abstract void Skill();

    public override void OnDeath()
    {
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item)
        {
            item.AddjustPlayerStatus(this);
        }
    }



}
