using UnityEngine;

public class MeleeMonster : Monster
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.InitializeEnemy(50, 10, 5, 5, 5, 10, 7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AttackType()
    {
        Debug.Log("ATK MEELEE");
    }
}
