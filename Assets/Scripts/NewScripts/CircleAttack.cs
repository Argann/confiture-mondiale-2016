using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace NewScripts
{
    public class CircleAttack : Attack
    {
        //Permet de définir la taille du cercle
        public float radius = 2f;
        private CircleCollider2D circle
        {
            get { return zoneAttaque as CircleCollider2D; }
            set { zoneAttaque = value; }
        }

        void Start()
        {
            circle = this.GetComponent<CircleCollider2D>();
            circle.radius = radius;
        }

        public override void LancerSkill()
        {
            List<GameObject> ennemy_list2 = new List<GameObject>(this.enemy_list);
            foreach (GameObject enemy in ennemy_list2)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<EnemyManager>().Blesser(damageAttack);
                }
                else
                {
                    this.enemy_list.Remove(enemy);
                }
            }
        }
    }
}