using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int Damage;
    public IShootable Shooter;


    public abstract void Move();

    public abstract void OnHitWith(Character charactor);

    public void InitProjectile(int newDamage, IShootable newShooter)
    {
        Damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x;

        if (value > 0)
        {
            return 1; //face right
        }
        else
        {
            return -1; //face left
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
        {
            OnHitWith(character);
            Destroy(this.gameObject, 5f);
        }
    }
}
