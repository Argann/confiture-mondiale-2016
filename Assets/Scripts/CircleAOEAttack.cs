using UnityEngine;
using System.Collections;

public class CircleAOEAttack : MonoBehaviour {

    GameObject projectile;
    public float cooldown = 1f;
    private float cooldownT;

    void Start () {
        cooldownT = cooldown;
    }
	
	void Update () {
        cooldownT -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && cooldownT <= 0)
        {
            cooldownT = cooldown;
            //List<GameObject> ennemy_list2 = new List<GameObject>(this.ennemy_list);
            var p1 = Instantiate(projectile) as GameObject;
            //p1.transform.SetParent(transform);
            //((projectile)p1).
           // p1.transform.localPosition = Vector3.zero;
           
        }
    }
}
