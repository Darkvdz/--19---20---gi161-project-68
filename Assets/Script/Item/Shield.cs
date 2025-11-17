using UnityEngine;

public class Shield : Item
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeItem(15, 0, 0);
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
