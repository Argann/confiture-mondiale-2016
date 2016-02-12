using UnityEngine;
using System.Collections;

namespace NewScripts
{
    public class FireBall : MonoBehaviour
    {

        public float radius = 0.5f;
        public float vitesse = 2;
        public int damageAttack = 5;
        private Vector3 movement;

        // Use this for initialization
        void Start()
        {
            Destroy(this.gameObject, 5);
            GetComponent<CircleCollider2D>().radius = radius;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            movement = (mousePos - transform.position).normalized * vitesse;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            GetComponent<Rigidbody2D>().velocity = movement;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                //TODO: Animation explosion
                collider.gameObject.GetComponent<EnemyManager>().Blesser(damageAttack);
                Destroy(this.gameObject);
            }
            else if (collider.gameObject.CompareTag("Wall"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}