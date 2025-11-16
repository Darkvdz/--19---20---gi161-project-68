using UnityEngine;

public abstract class Charactor : MonoBehaviour
{
    private int hp;

    public int Hp 
    { 
        get => hp;
        set => hp = (value <= 0) ? 0 : (value >= MaxHp) ? MaxHp : value; 
    }

    public int MaxHp { get; set; }

    public int Damage { get; set; }

    public int MoveSpeed { get; set; }


    public void TakeDamage() 
    {
    
    }

    public bool IsDead()
    {
        return hp <= 0;
    }

}
