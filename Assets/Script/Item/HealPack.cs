using UnityEngine;

public class HealPack : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(100);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AddjustPlayerStatus(Character hero)
    {
        hero.Hp += ItemStatus;
        Destroy(this.gameObject);
    }
}
