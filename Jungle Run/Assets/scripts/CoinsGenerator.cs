using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
	public ObjectPooler coinPooler;

	public void spwnCoins(Vector3 position, float platformWidth) {
		int random = Random.Range(0, 100);

		if (random < 50) {
			return;
		}

		int coinsNumber = (int)Random.Range(3f, platformWidth);
		for (int i=0; i<coinsNumber; i++) {
			GameObject coin = coinPooler.GetPooledGameObject();
			coin.transform.position = new Vector3(
				position.x - (platformWidth/2) + i,
				position.y + 4,
				0
			);
			coin.SetActive(true);
		}
	}    
}
