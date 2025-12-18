using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] column;
    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float timesSinceLastSpawned;
    private int currentColumn = 0;
    private float spawnXPosition = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        column = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            column [i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timesSinceLastSpawned += Time.deltaTime;
        if (GameControl.instance.gameOver == false == false && timesSinceLastSpawned >= spawnRate);
        {
            timesSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (columnMin, columnMax);
            column [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
