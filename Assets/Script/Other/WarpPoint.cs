using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    public Transform WarpTarget; 

    private bool alreadyWarp = false;


    public void WarpPlayer(GameObject player) 
    {
        if (!alreadyWarp)
        {
            alreadyWarp = true;
            
            if (WarpTarget != null)
            {
                player.transform.position = WarpTarget.position;
            }
            GameManager.Instance.nextLevel();
        }

    }

}
