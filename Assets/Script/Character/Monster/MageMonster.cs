using UnityEngine;

public class MageMonster : Monster
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeEnemy(25, 15, 3, 3, 15, 10, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AttackType()
    {
        throw new System.NotImplementedException();
    }

}
