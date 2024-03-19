using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    private float x = 0;
    private float y;
    private float maxX = 3f;
    private float xPos = 0;
    private float maxXPos = 3f;
    private float ySpacing = 0;
    private float maxSpacing = 10f;
    public List<GameObject> platforms;
    [SerializeField] public GameObject platform;

    void Start()
    {
        while (y >= -150)
        {
            x = Random.Range(0.2f, maxX) * 3;
            xPos = Random.Range(-3f, maxXPos) *3;
            ySpacing = Random.Range(0, maxSpacing);
            platforms.Add(Instantiate(platform, new Vector3(x, 0, 0), transform.rotation));
            platforms[platforms.Count - 1].transform.position = new Vector3(xPos, -12 + y);
            platforms[platforms.Count - 1].transform.localScale = new Vector2(x, 0.5f);
            y-= ySpacing;
        }

    }
}
