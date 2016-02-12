using UnityEngine;
using System.Collections;

namespace NewScripts
{
    public class CooldownManager : MonoBehaviour
    {
        //Sprite du cooldown 
        public SpriteRenderer cooldownBar;
        //Attaque courante sur laquelle le cooldown
        public Attack CurAttack;

        // Use this for initialization
        void Start()
        {
            if (cooldownBar == null)
            {
                cooldownBar = gameObject.GetComponent<SpriteRenderer>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 position = GameObject.FindGameObjectWithTag("Player").transform.position;
            this.cooldownBar.transform.position = new Vector3(position.x, position.y - 0.9f);
            if (CurAttack != null)
            {
                this.cooldownBar.transform.localScale = new Vector3(Mathf.Max(CurAttack.cooldownT / CurAttack.Cooldown, 0), 1);
            }
            else
            {
                this.cooldownBar.transform.localScale = new Vector3(0, 1);
            }
        }
    }
}