using UnityEngine;

public class Fireballs : Projectile
{
    [SerializeField] private float speed;
    private Vector2 direction;
   
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
        if (character is Hero)
        {
            character.TakeDamage(this);
            Destroy(this.gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 4.0f * GetShootDirection();
        Damage = 5;
    }
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
}
