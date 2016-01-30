using UnityEngine;
using System.Collections;

public class CanonBehaviour : MonoBehaviour {
	private int timer, countdown;

	public GameObject canonBall;

	// Use this for initialization
	void Start () {
		timer = 100;
		countdown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown > timer) {
			var ball = Instantiate (canonBall) as GameObject;
			ball.transform.SetParent(transform);
			ball.transform.localPosition = Vector3.zero;
			countdown = 0;
		}
		countdown++;
	}
}
