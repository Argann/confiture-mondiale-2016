using UnityEngine;
using System.Collections.Generic;

namespace NewScripts
{
    public abstract class Attack : MonoBehaviour
    {
        //Zone d'effet de l'attaque
        protected Collider2D zoneAttaque;
        //Liste des ennemis 
        protected List<GameObject> enemy_list = new List<GameObject>();
        //Gestion des dommages provoqués par l'attaque
        public int damageAttack;
        //Gestion du cooldown 
        public CooldownManager cooldownManager;
        public float Cooldown;
        public float cooldownT;
        //Objet auquel on attribue l'attaque - temporairement juste le joueur
        public PlayerManager player;
        //Clic lançant l'attaque
        public int KeyAttack;
        //Nom de l'animateur à activer lors du lancement de l'attaque
        public string animator_name;
        //ID de l'attaque
        public int IDAttack;

        private float lastCooldown;

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Enemy") && coll.gameObject.transform.GetComponent<EnemyManager>() != null)
            {
                this.enemy_list.Add(coll.gameObject);
            }
        }

        void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Enemy") && coll.gameObject.transform.GetComponent<EnemyManager>() != null)
            {
                this.enemy_list.Remove(coll.gameObject);
            }
        }

        //Fonction gérant ce que va faire l'attaque lors de son lancement
        public abstract void LancerSkill();

        void Update()
        {
            this.transform.position = player.transform.position;
            if (IDAttack == player.idAttack || IDAttack == -1)
            {
                if (cooldownManager != null)
                {
                    cooldownManager.CurAttack = this;
                }
                if (cooldownT > 0)
                {
                    cooldownT -= Time.deltaTime;
                }
                if (Input.GetMouseButtonDown(KeyAttack) && cooldownT <= 0)
                {
                    cooldownT = Cooldown;
                    this.player.arms_animator.SetBool(animator_name, true);
                    LancerSkill();
                }
                if (cooldownT <= Cooldown - 0.2f || Input.GetMouseButtonUp(KeyAttack))
                {
                    this.player.arms_animator.SetBool(animator_name, false);
                }
            }
        }
    }
}