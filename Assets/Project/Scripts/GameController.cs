using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Player player;
    public GameObject enemyPrefab;
    public GameObject gameCamera;
    public float enemySpawnInterval = 1f;
    public float horizontalLimit = 2.8f;

    private float enemySpawnTimer;

	// Use this for initialization
	void Start () {
        enemySpawnTimer = enemySpawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            enemySpawnTimer -= Time.deltaTime;
            if (enemySpawnTimer <= 0)
            {
                enemySpawnTimer = enemySpawnInterval;

                GameObject enemyInstance = Instantiate(enemyPrefab);
                enemyInstance.transform.SetParent(transform);
                enemyInstance.transform.position = new Vector2(
                    Random.Range(-horizontalLimit, horizontalLimit),
                    player.transform.position.y + Screen.height / 100f
                    );
            }
        }

        // Removing enemies
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            if (gameCamera.transform.position.y - enemy.transform.position.y > Screen.height / 100f)
            {
                Destroy(enemy.gameObject);
            }
        }
	}
}
