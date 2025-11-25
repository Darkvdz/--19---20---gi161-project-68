using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    private int hp;

    public int Hp 
    { 
        get => hp;
        set 
        { 
            hp = (value <= 0) ? 0 : (value >= MaxHp) ? MaxHp : value;
            print(this.name + " hp is " + hp);
            
            if (IsDead()) 
            {
                OnDeath();
            }
        }
    }

    public int MaxHp { get; set; }

    public int Damage { get; set; }

    public int MoveSpeed { get; set; }
    public float AtkCD { get; set; }
    [field:SerializeField] public int AtkRange { get; set; }


    protected Rigidbody2D rb;

    [SerializeField] private Slider hpBar;



    public void InitializeCharacter(int startHealth, int startDamage, int startMoveSpeed, float startAtkCD, int startAtkRange) 
    {
        MaxHp = startHealth;
        Hp = startHealth;

        Damage = startDamage;
        MoveSpeed = startMoveSpeed;

        AtkCD = startAtkCD;
        AtkRange = startAtkRange;

    }

    public virtual void TakeDamage(Character other) 
    {
        Hp -= other.Damage;
    }

    public virtual void TakeDamage(Projectile projectile)
    {
        Hp -= projectile.Damage;
    }

    public bool IsDead()
    {
        return hp <= 0;
    }
    public abstract void OnDeath();

}
