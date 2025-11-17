using UnityEngine;

public class Glove : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(0, 10, 0);
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
