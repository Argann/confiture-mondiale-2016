using System.Collections.Generic;
using UnityEngine;

namespace NewScripts
{
    public class ConeAttack : Attack
    {
        //Permet de définir la taille du cône d'attaque
        public float theta = 45f;
        public float distance = 2f;
        private PolygonCollider2D polygon
        {
            get { return zoneAttaque as PolygonCollider2D; }
            set { zoneAttaque = value; }
        }

        private Vector2 center, left, right, front;

        //L'angle Theta en radian
        private float rTheta;

        void Start()
        {
		    polygon = gameObject.GetComponent<PolygonCollider2D>();
            center = Vector2.zero;
        }

        public override void LancerSkill()
        {

            List<GameObject> ennemy_list2 = new List<GameObject>(this.enemy_list);
            foreach (GameObject enemy in ennemy_list2)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<EnemyManager>().Blesser(damageAttack + player.attackPower);
                }
                else
                {
                    this.enemy_list.Remove(enemy);
                }
            }
        }

        void FixedUpdate()
        {
            this.transform.rotation = player.transform.rotation;

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
    }
}
