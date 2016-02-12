using UnityEngine;
using System.Collections;

namespace NewScripts {
    public class EnemyAttack : MonoBehaviour {

        //Permet de définir la taille du cône d'attaque
        public float theta = 45f;
        public float distance = 2f;
        public PolygonCollider2D polygon;

        private Vector2 center, left, right, front;

        //L'angle Theta en radian
        private float rTheta;

        //Ennemi qui aura cette attaque
        public GameObject enemy;
        //Entité que l'ennemi veut attaquer - Pour l'instant par défaut, le joueur
        public PlayerManager player;
        //Dommage occasionné par l'ennemi
        public int damage = 10;
        public float cooldown = 0.5f;
        public float cooldownT;

        // Use this for initialization
        void Start() {
            if (player == null)
            {
                player = GameObject.Find("Player").GetComponent<PlayerManager>();
            }
        }

        // Update is called once per frame
        void FixedUpdate() {
            this.transform.rotation = enemy.transform.rotation;

            //angle degree to radian
            rTheta = theta * Mathf.Deg2Rad;

            //calcul distance pts central
            front = new Vector2(distance, 0);

            //calcul pts gauche
            float x = center.x + (front.x - center.x) * Mathf.Cos(-rTheta) - (front.y - center.y) * Mathf.Sin(-rTheta);
            float y = center.y + (front.y - center.y) * Mathf.Cos(-rTheta) + (front.x - center.x) * Mathf.Sin(-rTheta);
            left.Set(x, y);

            //calcul pts droit
            float x2 = center.x + (front.x - center.x) * Mathf.Cos(rTheta) - (front.y - center.y) * Mathf.Sin(rTheta);
            float y2 = center.y + (front.y - center.y) * Mathf.Cos(rTheta) + (front.x - center.x) * Mathf.Sin(rTheta);
            right.Set(x2, y2);

            //changement polygon
            polygon.points = new Vector2[] { center, left, front, right };
        }

        void Update()
        {
            if (cooldownT > 0)
            {
                cooldownT -= Time.deltaTime;
            }
        }

        void OnTriggerStay2D(Collider2D coll)
        {
            if (coll.gameObject == player.gameObject && cooldownT <= 0)
            {
                player.Touched(damage);
                cooldownT = cooldown;
            }
        }
    }
}