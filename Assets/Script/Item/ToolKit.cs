using UnityEngine;

public class ToolKit : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(5);
        
        GetComponent<Collider2D>().enabled = false;
        Invoke("EnablePickup", 1.0f);
    }

    public override void AddjustPlayerStatus(Character hero)
    {
        hero.Damage += ItemStatus;
        Destroy(this.gameObject);
    }
    
    void EnablePickup()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
