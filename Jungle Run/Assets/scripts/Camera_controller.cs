using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
	private Player player;
	private Vector3 last_position;
	private float distance;

    void Start()
    {
        player = FindObjectOfType<Player>();
        last_position = player.transform.position;
    }

    void Update()
    {
        distance = player.transform.position.x - last_position.x;
        transform.position = new Vector3(
        	transform.position.x + distance,
        	transform.position.y,
        	transform.position.z
        );
        last_position = player.transform.position;
    }
}
