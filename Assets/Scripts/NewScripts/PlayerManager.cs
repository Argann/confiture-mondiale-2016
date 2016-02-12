using UnityEngine;
using System.Collections.Generic;

namespace NewScripts
{
    public class PlayerManager : MonoBehaviour
    {
        #region Infos player
        //Niveau du joueur
        public int level;
        //XP actuel du personnage dans ce niveau
        public int curLevelxp;
        //xpMax du niveau en cours (xpMin = 0)
        private int xpMax
        {
            get { return 10 * level; }
        }
        //Puissance d'attaque - Permettra d'améliorer l'attaque
        public int attackPower;
        //Protection du personnage
        public int shield = 0;

        //Vie du joueur - Utile que pour le dernier niveau
        public bool useHealth = false;
        public int maxHealth = 100;
        public int health = 100;
        #endregion

        #region Infos gameobject player
        //Vitesse du joueur
        public float speed;

        //Player animator
        public Animator legs_animator;
        public Animator arms_animator;

        //Sprite de la barre de vie
        public GameObject healthbar = null;

        //ID de l'attaque en cours 
        public int idAttack;
        //Liste des attaques du joueur
        public List<GameObject> listAttacks;
        #endregion

        void Start()
        {
            if (listAttacks == null)
            {
                listAttacks = new List<GameObject>();
            }
            SkillsState.setRequirements();
            if (!useHealth)
            {
                this.healthbar.transform.localScale = new Vector3(0, 1);
            }
        }

        // Gestion du déplacement
        void FixedUpdate()
        {
            //Déplacement du personnage
            Vector2 direction = Vector2.up * Input.GetAxisRaw("up") + Vector2.left * Input.GetAxisRaw("left")
                + Vector2.down * Input.GetAxisRaw("down") + Vector2.right * Input.GetAxisRaw("right");
            float step = speed * Time.deltaTime;

            //Modification du sprite
            this.legs_animator.SetBool("isWalking", direction != Vector2.zero);
            this.arms_animator.SetBool("isWalking", direction != Vector2.zero);
            transform.position = Vector3.MoveTowards(transform.position, (Vector2)transform.position + direction, step);

            //Le sprite suit des yeux le curseur de la souris
            Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Affichage de la barre de vie
            if (this.healthbar != null)
            {
                this.healthbar.transform.position = new Vector3(transform.position.x, transform.position.y - 0.7f);
            } 
        }

        //Gestion de la vie
        void Update()
        {
            //Vérification de la mort du personnage
            if (health <= 0 && useHealth)
            {
                Destroy(this.transform.parent.gameObject);
            }

            //Gestion du changement d'attaque courante
            //Flammes - sans sprite pour le moment
            if (InputBroker.GetKeyDown(KeyCode.Alpha1) && idAttack != 1)
            {
                if (SkillsState.isAccessible("wider", level))
                    idAttack = 1;
                InputBroker.UnsetKeyDown(KeyCode.Alpha1);
            }
            //Boule de feu
            if (InputBroker.GetKeyDown(KeyCode.Alpha2) && idAttack != 2)
            {
                if (SkillsState.isAccessible("fireball", level))
                    idAttack = 2;
                InputBroker.UnsetKeyDown(KeyCode.Alpha2);
            }
            //Ronces
            if (InputBroker.GetKeyDown(KeyCode.Alpha3) && idAttack != 3)
            {
                if (SkillsState.isAccessible("around", level))
                    idAttack = 3;
                InputBroker.UnsetKeyDown(KeyCode.Alpha3);
            }
            //Shield - temporairement CaC
            if (InputBroker.GetKeyDown(KeyCode.Alpha4) && idAttack != 4)
            {
                if (SkillsState.isAccessible("shield", level))
                    idAttack = 4;
                InputBroker.UnsetKeyDown(KeyCode.Alpha4);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        #region World Interaction
        //A déclencher quand le joueur est touché
        public void Touched(int damage)
        {
            if (useHealth)
            {
                health -= damage;
                healthbar.transform.localScale = new Vector3((float)health / maxHealth, 1);
            }
            damage -= shield;
            if ((this.level < 100) || (this.level == 100 && curLevelxp < 1000))
            {
                curLevelxp += Mathf.Max(damage, 0);
                if (curLevelxp >= xpMax)
                {
                    int xpMore = curLevelxp % xpMax;
                    NewLevel(level + 1, true);
                    curLevelxp += xpMore;
                }
            }
        }

        //A déclencher quand le joueur tue un/des ennemi(s)
        public void KillEnemies(int xpMonster, int count = 1)
        {
            if (this.level > 1)
            {
                curLevelxp -= count * xpMonster;
                if (curLevelxp <= 0)
                {
                    int xpLess = curLevelxp;
                    NewLevel(level - 1, false);
                    curLevelxp += xpLess;
                }
            }
        }

        //Permet d'affecter un nouveau niveau au joueur
        private void NewLevel(int level, bool levelup)
        {
            this.level = level;
            curLevelxp = (levelup ? 0 : xpMax);
        }
        #endregion
    }
}
