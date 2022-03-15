using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomResourceGenerator : MonoBehaviour
{
    public GameObject player;
    public Tilemap tilemap;
    public int[,] terrainMap;
    public TileBase tileGrass, tileWater;
    public int width, height;
    public float scale = 20f;
    public float seed;
    public GameObject[] resourceList;
    public GameObject[] grassAndPebble;
    List<Vector2> posList = new List<Vector2>();
    public float minSpacing, maxSpacing, clumpThreshold, spawnRate;
    void Awake()
    {
        if (seed == 0)
        {
            seed = Random.Range(-10000f, 10000f);
        }
        terrainMap = new int[width, height];
        terrainMap = MapGenerator(terrainMap);
        RenderMap(terrainMap);
        SpawnPlayer();
    }
    private void SpawnPlayer()
    {
        bool isNotSpawned = true;
        while (isNotSpawned)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (terrainMap[x, y] == 1)
            {
                player.transform.position = new Vector2(x, y);
                player.SetActive(true);
                isNotSpawned = false;
            }
        }
    }
    private bool CheckWithinSpacing(List<Vector2> vector2List, Vector2 vector)
    {
        float spacing = Random.Range(minSpacing, maxSpacing);
        foreach (Vector2 vector1 in vector2List)
        {
            if (Mathf.Abs(vector1.x - vector.x) < spacing && Mathf.Abs(vector1.y - vector.y) < spacing)
            {
                return true;
            }
        }
        vector2List.Add(vector);
        return false;
    }
    void RenderMap(int[,] map)
    {
        tilemap.ClearAllTiles();
        for (int x = -20; x < width + 20; x++)
        {
            for (int y = -20; y < height + 20; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), tileWater);
            }
        }
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (map[x, y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileGrass);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tileWater);
                }
            }
        }
    }

    int[,] MapGenerator(int[,] map)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * scale + seed;
                float yCoord = (float)y / height * scale + seed;
                if (Mathf.PerlinNoise(xCoord, yCoord) >= 0.25)
                {
                    seekResourceClumpPoint(Mathf.PerlinNoise(xCoord, yCoord), new Vector2(x, y));
                    for (int i = 0; i < 4; i++)
                    {
                        if (Random.Range(1, 100) >= 75)
                        {
                            spawnGrassAndPebble(new Vector2(x + Random.Range(0.1f, 0.9f), y + Random.Range(0.1f, 0.9f)));
                        }
                    }
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }
    void seekResourceClumpPoint(float perlinNoiseValue, Vector2 pos)
    {
        if (CheckWithinSpacing(posList, pos) && perlinNoiseValue < clumpThreshold) return;
        if (Random.Range(1, 100) <= spawnRate)
        {
            Instantiate(resourceList[Random.Range(0, resourceList.Length)], new Vector2(pos.x + Random.Range(0.3f, 0.8f), pos.y + Random.Range(0.3f, 0.8f)), Quaternion.identity);
        }
    }
    void spawnGrassAndPebble(Vector2 pos)
    {
        Instantiate(grassAndPebble[Random.Range(0, grassAndPebble.Length)], pos, Quaternion.identity);
    }
}
