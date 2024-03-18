using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    float x = 0;
    float y;
    float maxY = 3f;
    public List<GameObject> platforms;
    [SerializeField] public GameObject platform;

    void Start()
    {
        while (x <= 24)
        {
            y = Random.Range(0.2f, maxY) * 10;
            platforms.Add(Instantiate(platform, new Vector3(-1000, y, -1000), transform.rotation));
            platforms[platforms.Count - 1].transform.position = new Vector3(-12 + x, -5);
            platforms[platforms.Count - 1].transform.localScale = new Vector2(3.5f, y);
            x++;
        }

    }
}
