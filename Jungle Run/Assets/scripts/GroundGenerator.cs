using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	public Transform generation_point;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;

	public ObjectPooler[] groundPoolers;
	private float[] ground_widths;

    private CoinsGenerator coinGenerator;
    private EnemyGenerator enemyGenerator;

    void Start()
    {
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;

     	ground_widths = new float[groundPoolers.Length];
     	for(int i=0; i<groundPoolers.Length; i++) {
     		ground_widths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
     	}

        coinGenerator = FindObjectOfType<CoinsGenerator>();
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
    }

    void Update()
    {
        if(transform.position.x < generation_point.position.x) {
        	int random = Random.Range(0, groundPoolers.Length);
        	float distance = ground_widths[random]/2;

            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);
        	transform.position = new Vector3(
        		transform.position.x + distance + gap, 
        		height,
        		transform.position.z
        	);

        	GameObject ground = groundPoolers[random].GetPooledGameObject();
        	ground.transform.position = transform.position;
        	ground.SetActive(true);

            coinGenerator.spwnCoins(transform.position, ground_widths[random]);
            enemyGenerator.spwnEnemies(transform.position, ground_widths[random]);

        	transform.position = new Vector3(
        		transform.position.x + distance, 
        		transform.position.y,
        		transform.position.z
        	);
        }
    }
}
