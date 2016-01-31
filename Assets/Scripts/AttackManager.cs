using UnityEngine;
using System.Collections;

public class AttackManager : MonoBehaviour {

    public GameObject fireBall;

    public float cooldown = 1f;
    [HideInInspector] // Hides var below
    public float cooldownT;

    void Start()
    {
        cooldownT = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownT -= Time.deltaTime;
        if (cooldownT <= 0 && Input.GetMouseButtonDown(0))
        {
            cooldownT = cooldown;
            Instantiate(fireBall, transform.position, transform.rotation);
        }
    }
}