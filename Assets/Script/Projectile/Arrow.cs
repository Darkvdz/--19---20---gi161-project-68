using UnityEngine;

public class Arrow : Projectile
{
    [SerializeField] private float speed;
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this);
            Destroy(this.gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 4.0f * GetShootDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override int GetShootDirection()
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
}
