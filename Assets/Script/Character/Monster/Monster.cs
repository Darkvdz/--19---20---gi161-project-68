using UnityEngine;

public abstract class Monster : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        throw new System.NotImplementedException();
    }

    public abstract void AttackType();

}
