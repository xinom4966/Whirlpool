using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    float x = 0;
    float y;
    float maxX = 3f;
    public List<GameObject> platforms;
    [SerializeField] public GameObject platform;

    void Start()
    {
        while (y <= 50)
        {
            x = Random.Range(0.2f, maxX) * 10;
            platforms.Add(Instantiate(platform, new Vector3(x, -1000, -1000), transform.rotation));
            platforms[platforms.Count - 1].transform.position = new Vector3(0, -20 + y);
            platforms[platforms.Count - 1].transform.localScale = new Vector2(x, 0.5f);
            y++;
        }

    }
}
