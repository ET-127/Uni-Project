using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    float intTime;
    public float destructTime;
    public float dmg;
    public GameObject source;
    public Color color;

	// Use this for initialization
	void Awake () {

        intTime = Time.time;
		
	}

    private void Start()
    {
        GetComponent<Light>().color = color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject != source)
        {
            Debug.Log(source.name);

            if (other.transform.root.GetComponent<Player>() != null)
            {

                other.transform.root.GetComponent<Player>().health -= dmg;
                Destroy(gameObject);


            }
            else if (other.transform.root.GetComponent<Enemy>() != null)
            {

                other.transform.root.GetComponent<Enemy>().health -= dmg;
                Destroy(gameObject);

            }

        }

    }

    // Update is called once per frame
    void Update () {

        if ((Time.time - intTime) >= destructTime){

            Destroy(gameObject);

        }
		
	}
}
