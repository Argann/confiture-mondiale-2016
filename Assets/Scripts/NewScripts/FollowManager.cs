using UnityEngine;
using System.Collections;

namespace NewScripts
{
    public class FollowManager : MonoBehaviour
    {

        //Vitesse de l'ennemi
        public float speed;
        //Objet que l'ennemi va suivre
        public GameObject followed;
        //Pour savoir si l'ennemi suit followed
        private bool followFollowed;
        //Distance à laquelle il détecte followed
        public float distance;

        // Use this for initialization
        void Start()
        {
            this.GetComponent<CircleCollider2D>().radius = distance;
            if (followed == null)
            {
                followed = GameObject.Find("Player");
            }
        }

        void FixedUpdate()
        {
            //Si l'enemi suit l'entité à suivre
            if (followFollowed)
            {
                Transform parent = this.transform.parent;
                //print(parent);

                //Il cherche à se rapprocher de lui
                parent.position = Vector3.MoveTowards(parent.position, followed.transform.position, speed * Time.deltaTime);

                //Et le regarde
                Vector3 dir = followed.transform.position - parent.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        #region Gestion de la vision de l'ennemi
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag(followed.tag))
            {
                followFollowed = true;
            }
        }

        void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag(followed.tag))
            {
                followFollowed = false;
            }
        }
        #endregion
    }
}