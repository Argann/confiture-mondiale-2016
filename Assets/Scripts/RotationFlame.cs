using UnityEngine;
using System.Collections;

public class RotationFlame : MonoBehaviour {

	public float coolDown ;
	private float coolDownT ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,0,transform.localScale.x));
	}
}
