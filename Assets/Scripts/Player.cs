using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = Vector2.up * Input.GetAxisRaw("up") + Vector2.left * Input.GetAxisRaw("left")
                            + Vector2.down * Input.GetAxisRaw("down") + Vector2.right * Input.GetAxisRaw("right");
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction, step);

        Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
