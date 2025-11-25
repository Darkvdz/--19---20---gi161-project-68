using UnityEngine;

public interface ISlashable 
{
    //Auto property
    public GameObject SlashEffect { get; set; }
    public Transform SlashPoint { get; set; }
    public float SlashTime { get; set; }
    public float WaitTime { get; set; }


    //Method
    public void Slash();
}
