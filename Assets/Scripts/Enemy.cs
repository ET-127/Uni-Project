using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Stats")]
    public float maxHP = 200;
    public float health = 200;
    public float rpm = 1;

    [Header("Movement")]
    Rigidbody rb;

    public Transform player;
    public GameObject projectile;
    public Transform spawnPoint;
    public Transform model;
  

    bool LOS = true;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        model = transform.GetChild(0);
        player = FindObjectOfType<Player>().transform;

    }

    void Update()
    {

        Aim();
        Death(health);

    }

    void Aim()
    {
        if (LOS) {

            //Get the mouse's current position on the screen

            Debug.DrawLine(model.position, player.position);

            Vector3 dir = player.position - model.position;
            transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

        }

    }

    void Death(float hp){

        if (hp <= 0)
        {
            
            Destroy(gameObject);
            
        }

    }


}
