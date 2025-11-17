using UnityEngine;

public class Boot : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AddjustPlayerStatus()
    {
        throw new System.NotImplementedException();
    }
}
