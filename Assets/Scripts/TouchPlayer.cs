using UnityEngine;
using System.Collections;

public class TouchPlayer : MonoBehaviour {

    public Player player;

	private bool onSpike, onFlame;

	void Start() {
		onSpike = false;
	}
	
	void OnTriggerEnter2D(Collider2D hitbox) {
		if (hitbox.gameObject.CompareTag ("Enemy")) {
			player.Touched (5);
		} else if (hitbox.gameObject.CompareTag ("Spike")) {
			onSpike = true;
		} else if (hitbox.gameObject.CompareTag ("FlameThrower")) {
			onFlame = true;
		} else if (hitbox.gameObject.CompareTag ("SlowZone")) {
			player.speed /= 2;
		} else if (hitbox.gameObject.CompareTag ("CanonBall")) {
			player.Touched (35);
		}
    }

	void OnTriggerExit2D(Collider2D hitbox) {
		if (hitbox.gameObject.CompareTag("Spike")) {
			onSpike = false;
		} else if (hitbox.gameObject.CompareTag("FlameThrower")) {
			onFlame = false;
		} else if (hitbox.gameObject.CompareTag ("SlowZone")) {
			player.speed *= 2;
		}
	}

	void Update() {
		if (onSpike)
			player.Touched (1);
		if (onFlame)
			player.Touched (5);
	}
}
