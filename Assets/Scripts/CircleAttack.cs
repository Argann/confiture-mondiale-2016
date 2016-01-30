using UnityEngine;
using System.Collections;

public class CircleAttack : MonoBehaviour {

    public float radius = 2f;
    private CircleCollider2D circle;
    // Use this for initialization
    void Start () {
        circle = this.GetComponent<CircleCollider2D>();
        circle.radius = radius;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
