using UnityEngine;

public class HealPack : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(100);
        
        GetComponent<Collider2D>().enabled = false;
        Invoke("EnablePickup", 0.8f);
    }

    public override void AddjustPlayerStatus(Character hero)
    {
        hero.Hp += ItemStatus;
        Destroy(this.gameObject);
    }
    
    void EnablePickup()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
