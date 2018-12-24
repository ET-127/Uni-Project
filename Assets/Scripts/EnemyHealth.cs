using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Enemy source;
    public Slider slider;
    public float offsetY;

    private void Awake()
    {

        slider = GetComponent<Slider>();

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = (source.health / source.maxHP);
        Vector3 pos = new Vector3(source.model.transform.position.x, source.model.transform.position.y, source.model.transform.position.z + offsetY);
        slider.transform.position = Camera.main.WorldToScreenPoint(pos);

		
	}
}
