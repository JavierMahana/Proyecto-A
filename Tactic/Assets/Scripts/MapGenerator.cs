﻿using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public enum GenerationMode {ByTexture, Procedual};
    public GenerationMode generationMode;
    [Header("By Texture MapGeneration Variables")]
    public Texture2D level;
    public ColorToTerrain[] colorMappings;

    [Header("Procedual MapGeneration Variables")]
    public int mapWidth = 1;
    public int mapHeight = 1;
    public float scale;
    public int seed;
    public Vector2 offSet;
    [Range(1,20)]
    public int octaves = 1;
    [Range(0f,1f)]
    public float persistace = .5f;
    public float lacunarity = 2;

    public bool autoUpdateInEditor;

    
    public Map map;

    [HideInInspector]
    public Mesh mesh;

    

    void Start()
    {
        Debug.Log("hi");
        GenerateMapWithNoiseMap();
        //GenerateMapByTexture();
        
    }
    private void OnValidate()
    {
        if (mapHeight < 1)
        {
            mapHeight = 1;
        }
        if (mapWidth < 1)
        {
            mapWidth = 1;
        }
        if (lacunarity < 1)
        {
            lacunarity = 1;
        }
        if (octaves < 0)
        {
            octaves = 0;
        }
        if (scale < 0.00001)
        {
            scale = 0.00001f;
        }
    }

    public void GenerateMapWithNoiseMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, offSet,octaves,persistace,lacunarity, scale);


        MapDisplay mapDisplay = FindObjectOfType<MapDisplay>();

        Debug.Log("se accede a map display");
        mapDisplay.CreateMapUsingNoiseMap(noiseMap);

    }

    public void GenerateMapByTexture()
    {
        GenerateMap();
        GenerateMapGO(level.width, level.height);
    }
    void GenerateMap()
    {
        map = new Map(ref level, ref colorMappings);
    }

    
    void GenerateMapGO(int xSize, int ySize)
    {
        GameObject map = new GameObject("Map");
        map.transform.SetParent(this.gameObject.transform);

        GenerateSprites(xSize, ySize, map);
        GenerateMesh(xSize, ySize, map);
    }
    /// <summary>
    /// Generate Sprites GO
    /// </summary>
    /// <param name="xSize"></param>
    /// <param name="ySize"></param>
    /// <param name="map">map parent</param>
    void GenerateSprites(int xSize, int ySize, GameObject map)
    {
        Map mapComp = map.GetComponentInParent<MapGenerator>().map;

        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                

                GameObject newSprite = new GameObject();
                newSprite.transform.SetParent(map.transform);
                SpriteRenderer sprtRenderer = newSprite.AddComponent<SpriteRenderer>();
                Tile tile = mapComp.GetTile(x, y);

                newSprite.transform.position = new Vector3(x, y, 0);

                sprtRenderer.sprite = tile.terrain_.visual;

                newSprite.name = tile.terrain_.name + " Sprite";


            }
        }

    }

    void GenerateMesh(int xSize, int ySize, GameObject map)
    {
        
        Mesh mesh;
        mesh = map.AddComponent<MeshFilter>().sharedMesh;
        mesh = map.AddComponent<MeshCollider>().sharedMesh;

        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(0 , 0 , 0);
        vertices[1] = new Vector3(xSize , 0 , 0);
        vertices[2] = new Vector3(0 , ySize , 0);
        vertices[3] = new Vector3(xSize , xSize , 0);

        mesh.vertices = vertices;

        int[] triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        mesh.triangles = triangles;

    }

}
