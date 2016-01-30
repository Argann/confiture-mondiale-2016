using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

    public float vitesse;
    public Vector3 angles;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float step = vitesse * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x+10,transform.position.y), step);
          //  localPosition = new Vector3(transform.localPosition.x + 0.1f, transform.localPosition.y, 0f);
    }

    void setAngles(Vector3 angles)
    {
        this.angles = angles;
    }
}
