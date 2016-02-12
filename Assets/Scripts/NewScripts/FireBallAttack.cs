using UnityEngine;
using System.Collections;

namespace NewScripts
{
    public class FireBallAttack : Attack
    {
        public GameObject fireBall;

        public override void LancerSkill()
        {
            Instantiate(fireBall, transform.position, player.transform.rotation);            
        }
    }
}