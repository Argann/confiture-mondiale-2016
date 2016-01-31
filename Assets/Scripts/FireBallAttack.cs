using UnityEngine;
using System.Collections;

public class FireBallAttack : MonoBehaviour {

    public float radius = 0.5f;
    public float vitesse = 2;
    public int damage = 10;
    private Vector3 movement;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10);
        GetComponent<CircleCollider2D>().radius = radius;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        //float coeff = vitesse / Vector3.Normalize();
        movement = (mousePos - transform.position).normalized * vitesse;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Ennemy"))
        {
            //TODO: Animation explosion
            collider.GetComponent<Ennemy>().Blesser(damage);
            Destroy(this.gameObject);
        }
    }
}