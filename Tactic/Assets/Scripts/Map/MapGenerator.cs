using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public enum GenerationMode {ByTexture, Procedual};
    public GenerationMode generationMode;

    public Texture2D level;
    public ColorToTerrain[] colorMappings;
    public Map map;

    [HideInInspector]
    public Mesh mesh;

    

    void Start()
    {
        Generate();
        
    }

    public void Generate()
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
        mesh = map.AddComponent<MeshFilter>().mesh;
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
