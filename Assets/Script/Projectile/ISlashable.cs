using UnityEngine;

public interface ISlashable 
{
    //Auto property
    public GameObject SlashEffect { get; set; }
    public Transform SlashPoint { get; set; }
    

    //Method
    public void Slash();
}
