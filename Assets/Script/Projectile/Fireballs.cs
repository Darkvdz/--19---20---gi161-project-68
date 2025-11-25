using UnityEngine;

public class Fireballs : Projectile
{
    [SerializeField] private float speed;
    private Vector2 direction;

    private bool alreadyDealDamage = false;
   
    public override void Move()
    {
        /*float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;*/
        transform.position += (Vector3)(direction * speed * Time.fixedDeltaTime);
    }
    
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    public override void OnHitWith(Character character)
    {
        if ((character is Hero) && !alreadyDealDamage)
        {
            alreadyDealDamage = true;
            character.TakeDamage(this);
            Destroy(this.gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 4.0f * GetShootDirection();
    }
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override int GetShootDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            return 1; // default face right

        float value = player.transform.position.x - transform.position.x;

        if (value > 0)
        {
            return 1; //face right
        }
        else
        {
            return -1; //face left
        }
        ;
    }
}
