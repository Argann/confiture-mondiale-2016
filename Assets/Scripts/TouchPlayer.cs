using UnityEngine;
using System.Collections;

public class TouchPlayer : MonoBehaviour {

    public Player player;

	private bool onSpike;

	void Start() {
		onSpike = false;
	}
	
	void OnTriggerEnter2D(Collider2D hitbox) {
		if (hitbox.gameObject.CompareTag("Enemy")) {
            player.Touched(5);
		} else if (hitbox.gameObject.CompareTag("Spike")) {
			onSpike = true;
		}
    }

	void OnTriggerExit2D(Collider2D hitbox) {
		if (hitbox.gameObject.CompareTag("Spike")) {
			onSpike = false;
		}
	}

	void Update() {
		if (onSpike)
			player.Touched (100);
	}
}
