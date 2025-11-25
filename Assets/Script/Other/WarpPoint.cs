using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public Transform WarpTarget; // จุดปลายทางใน scene เดียวกัน

    public void WarpPlayer(GameObject player) 
    {
        player.transform.position = WarpTarget.position;
        GameManager.Instance.nextLevel();

    }

}
