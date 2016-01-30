using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
           Destroy(other.gameObject);
        }
    }
}
