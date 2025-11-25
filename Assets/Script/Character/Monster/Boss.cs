using UnityEngine;

public class Boss : Enemy
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeEnemy(100,35,5,7,5,20,12);
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Behavior()
    {
        throw new System.NotImplementedException();
    }

    public override void Chasing(Hero target)
    {
        throw new System.NotImplementedException();
    }
    
    public override void CoinDrop()
    {
        OnDeathDrop();
    }
    
    public void OnDeathDrop() 
    {
    
    }
}
