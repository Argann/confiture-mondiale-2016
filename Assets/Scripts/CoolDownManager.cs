using UnityEngine;
using System.Collections;

public class CoolDownManager : MonoBehaviour {
    private SpriteRenderer cooldownBar;
    private float coolDown, coolDownT;
    private Quaternion rotation;
    // Use this for initialization
    void Start () {
        rotation = this.transform.rotation;
        cooldownBar = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        coolDown = this.transform.parent.gameObject.GetComponentInChildren<AttackEnemy>().cooldown;
        coolDownT = this.transform.parent.gameObject.GetComponentInChildren<AttackEnemy>().cooldownT;
        if (this.coolDownT <= 0) coolDownT = 0;
        //   this.cooldownBar.transform.rotation = rotation;
        Vector3 position = GameObject.Find("Joueur").transform.position;
        this.cooldownBar.transform.position = new Vector3(position.x,position.y-0.7f);
        this.cooldownBar.transform.localScale = new Vector3(coolDownT / coolDown, 1);

        
    }
}
