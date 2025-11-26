using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public Transform WarpTarget; // จุดปลายทางใน scene เดียวกัน

    private bool alreadyWarp = false;


    public void WarpPlayer(GameObject player) 
    {
        if (!alreadyWarp)
        {
            alreadyWarp = true;
            player.transform.position = WarpTarget.position;
            GameManager.Instance.nextLevel();
        }

    }

}
