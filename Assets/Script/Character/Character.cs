using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private int hp;

    public int Hp 
    { 
        get => hp;
        set 
        { 
            hp = (value <= 0) ? 0 : (value >= MaxHp) ? MaxHp : value;

            if (IsDead()) 
            {
                OnDeath();
            }
        }
    }

    public int MaxHp { get; set; }

    public int Damage { get; set; }

    public int MoveSpeed { get; set; }
    public int AtkSpeed { get; set; }
    public int AtkRange { get; set; }


    public void InitializeCharacter(int startHealth, int startDamage, int startMoveSpeed, int startAtkSpeed, int startAtkRange) 
    {
        MaxHp = startHealth;
        Hp = startHealth;

        Damage = startDamage;
        MoveSpeed = startMoveSpeed;

        AtkSpeed = startAtkSpeed;
        AtkRange = startAtkRange;

    }

    public void TakeDamage(Character other) 
    {
        Hp -= other.Damage;
    }

    public bool IsDead()
    {
        return hp <= 0;
    }
    public abstract void OnDeath();

}
