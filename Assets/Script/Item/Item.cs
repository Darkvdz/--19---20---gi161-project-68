using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int ItemStatus { get; set; }

    public void InitializeItem(int Status)
    {
        ItemStatus = Status;
    }

    public abstract void AddjustPlayerStatus(Character hero);
}
