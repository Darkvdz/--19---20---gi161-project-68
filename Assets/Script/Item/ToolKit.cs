using UnityEngine;

public class ToolKit : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AddjustPlayerStatus(Character hero)
    {
        hero.Damage += ItemStatus;
        Destroy(this.gameObject);
    }
}
