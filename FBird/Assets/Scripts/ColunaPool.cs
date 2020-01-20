using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColunaPool : MonoBehaviour
{
    public int poolSize = 5;
    public GameObject colunaPrefab;
    public float spawnTimer = 3f;
    public float colunaMin = -3.2f;
    public float colunaMax = 1.34f;

    private GameObject[] colunas;
    private Vector2 objectPoolPosition = new Vector2(-15f, 25f);
    private float lastSpawnTimer;
    public float spawnXPosition = 10f;
    private int colunaAtual = 0;



    // Start is called before the first frame update
    void Start()
    {
        colunas = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            colunas[i] = (GameObject)Instantiate(colunaPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawnTimer += Time.deltaTime;

        if(!Gamecontrol.gameControl.gameOver && lastSpawnTimer >= spawnTimer)
        {
            lastSpawnTimer = 0;
            float spawnYPosition = Random.Range(colunaMin, colunaMax);
            colunas[colunaAtual].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            colunaAtual++;
                if (colunaAtual >= poolSize)
            {
                colunaAtual = 0;
            }
        }
    }
}
