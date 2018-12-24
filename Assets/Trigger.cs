using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")) {

            Vector3 roomCenter = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);

            Camera.main.GetComponent<SmoothMove>().movePos = roomCenter;

        }
    }
}
