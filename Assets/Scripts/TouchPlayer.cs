using UnityEngine;
using System.Collections;

public class TouchPlayer : MonoBehaviour {

    public Player player;
	
    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.gameObject.CompareTag("Enemy"))
        {
            player.Touched(5);
        }
    }
}
