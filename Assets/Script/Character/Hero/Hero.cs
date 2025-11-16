using UnityEngine;

public abstract class Hero : Charactor
{
    public int AtkSpeed { get; set; }
    public int AtkRange { get; set; }

    public Item[] ItemEquip { get; set; }

    public abstract void AttackType();

    public abstract void Skill();

}
