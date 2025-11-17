using UnityEngine;

public class Tank : Hero
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeHero(100, 20, 10, 5, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AttackType()
    {
        throw new System.NotImplementedException();
    }

    public override void Skill()
    {
        throw new System.NotImplementedException();
    }
}
