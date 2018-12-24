using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Stats")]
    public float health = 200;
    public float projSpeed;
    public float rps = 1;
    public float dmg;

    [Header("Movement")]
    public float m_moveVel;
    Rigidbody rb;
    Transform playerModel;

    bool fullauto;
    public GameObject projectile;
    public Transform spawnPoint;
    public bool controller;
    float time = 0;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        playerModel = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        Look();
        Shoot();

    }

    void Move()
    {
        if (!controller)
        {
            // Get the vertical and horizontal input
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            //Set the direction of motion
            Vector3 dir = new Vector3(h, 0, v);

            //Multiply the direction by the velocity
            rb.velocity = dir.normalized * m_moveVel * Time.deltaTime;

        } else
        {

            // Get the vertical and horizontal input
            float v = Input.GetAxis("LStickV");
            float h = Input.GetAxis("LStickH");

            //Set the direction of motion
            Vector3 dir = new Vector3(h, 0, v);

            //Multiply the direction by the velocity
            rb.velocity = dir.normalized * m_moveVel * Time.deltaTime;

        }
    }
    void Look()
    {
        if (!controller) {

            //Get the mouse's current position on the screen
            Vector3 mousePos = Input.mousePosition;
            mousePos = new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y - playerModel.position.y);
            transform.LookAt(Camera.main.ScreenToWorldPoint(mousePos));

        } else
        {

            float v = Input.GetAxis("RStickV");
            float h = Input.GetAxis("RStickH");

            Vector3 inp = new Vector3(v,0,h);

            transform.LookAt(transform.position + (inp.normalized * 2));
            
        }

    }
    void Shoot()
    {

        if (time >= (1 / rps))
        {

            if (Input.GetAxis("Fire1") != 0 || Input.GetAxis("FireC1") != 0)
            {
                GameObject p = (GameObject)Instantiate(projectile, spawnPoint.position, transform.rotation);

                //p.GetComponentInChildren<Light>().color = new Color(0, 123, 180,255);
                p.GetComponent<SelfDestruct>().source = gameObject;
                p.GetComponent<SelfDestruct>().dmg = dmg;
                p.GetComponent<Rigidbody>().velocity = transform.forward * projSpeed;

                time = 0;
            }

        }

        time += Time.deltaTime;
    

    }

}
