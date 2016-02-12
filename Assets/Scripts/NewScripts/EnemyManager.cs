using UnityEngine;
using System.Collections;

namespace NewScripts {
    public class EnemyManager : MonoBehaviour {
        #region Enemy Infos
        //Vie maximale de l'ennemi - temporairement 100
        public int maxHealth = 100;
        //Vie de l'ennemi
        public int health;
        //Bouclier de l'ennemi
        public int shield;
        public int xp;
        #endregion
        public GameObject healthbar;

        // Use this for initialization
        void Start() {
            health = maxHealth;
        }

        public void Blesser(int degats)
        {
            this.health -= Mathf.Max(degats - shield, 0);
            healthbar.transform.localScale = new Vector2(Mathf.Max((float)this.health / this.maxHealth, 0.0f), 1.0f);
        }

        void Update()
        {
            if (this.health <= 0)
            {
                GameObject.Find("Player").GetComponent<PlayerManager>().KillEnemies(xp * GameObject.Find("Player").GetComponent<PlayerManager>().level);
                Destroy(this.gameObject);
            }
        }

        void FixedUpdate()
        {
            healthbar.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
        }
    }
}