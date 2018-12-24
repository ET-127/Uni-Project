using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{

    public float smoothTime;
    public Vector3 movePos;
    Vector3 vel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position,movePos,ref vel,smoothTime);
        
    }
}
