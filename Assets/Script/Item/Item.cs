using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int AddHp { get; set; }

    public int AddDamage { get; set; }

    public int AddSpeed { get; set; }

    public void InitializeItem(int statusHp, int statusDamage, int statusSpeed)
    {
        AddHp = statusHp;
        AddDamage = statusDamage;
        AddSpeed = statusSpeed;
    }

    public abstract void AddjustPlayerStatus();
}
