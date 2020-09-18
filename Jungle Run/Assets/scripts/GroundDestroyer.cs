using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
	private GameObject point;

    void Start()
    {
    	point = GameObject.Find("ground_distroy");
        
    }

    void Update()
    {
        if(transform.position.x < point.transform.position.x) {
        	gameObject.SetActive(false);
        }
    }
}
