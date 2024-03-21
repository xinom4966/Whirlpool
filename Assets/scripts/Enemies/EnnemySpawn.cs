using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawn : MonoBehaviour
{
    private float x = 0;
    private float y;
    private float maxX = 3f;
    private float xPos = 0;
    private float maxXPos = 3f;
    private float ySpacing = 0;
    private float maxSpacing = 10f;
    private int enemyRandomizer;
    public List<GameObject> ennemies;
    [SerializeField] public GameObject enemy1;
    [SerializeField] public GameObject enemy2;

    void Start()
    {
        while (y >= -100)
        {
            enemyRandomizer = Random.Range(0, 2);
            x = Random.Range(0.2f, maxX) * 3;
            xPos = Random.Range(-3f, maxXPos) * 3;
            ySpacing = Random.Range(1, maxSpacing);
            if (enemyRandomizer == 0)
            {
                ennemies.Add(Instantiate(enemy1, new Vector3(x, 0, 0), transform.rotation));
            }
            else if (enemyRandomizer == 1)
            {
                ennemies.Add(Instantiate(enemy2, new Vector3(x, 0, 0), transform.rotation));
            }
            ennemies[ennemies.Count - 1].transform.position = new Vector3(xPos, -12 + y);
            y -= ySpacing;
        }

    }
}
