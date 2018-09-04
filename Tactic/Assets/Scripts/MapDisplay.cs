using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapDisplay : MonoBehaviour {

    public GameObject parentMap;
    public NoiseToTerrain[] terrainMapings;
    public GameObject tileTemplate;

    private List<TileProp> almacenedTiles = new List<TileProp>();
    private int almacenedWidth;
    private int almacenedHeight;

    


    public Renderer textureRenderer;



    public void CreateMapUsingNoiseMap (float[,]noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        //las proporciones se ajustan
        //Se crean tiles vacias si es necesario
        Debug.Log("antes de ajustar las proporciones");
        UpdateMapProportions(width, height);


        //Se actualizan los datos de las tiles
        //Y a las tiles vacias se les asignan datos
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                SetTerrainData(noiseMap, GetTileData(new Vector2(x,y)), x, y);
            }
        }

    }

    private void UpdateMapProportions(int width ,int height)
    {
        int heightDiference = height - almacenedHeight;
        int widthDiference = width - almacenedWidth;

        //las proporciones estan ok
        Debug.Log("primerChequeo");
        if (heightDiference == 0 && widthDiference ==0)
        {
            return;
        }
        //
        Debug.Log("entrando a los while loops");
        while (heightDiference != 0)
        {
            Debug.Log(" while loop 1");
            int yWhile = almacenedHeight - 1;

            if (heightDiference < 0)
            {
                
                for (int x = 0; x < almacenedWidth; x++)
                {
                    DestroyTile(x, yWhile);
                }
                heightDiference++;
                almacenedHeight--;

            }
            else if (heightDiference > 0)
            {
                
                for (int x = 0; x < almacenedWidth; x++)
                {
                    CreateTileTemplate(x, yWhile + 1);
                }
                heightDiference--;
                almacenedHeight++;
            }
        }


        
        while (widthDiference !=0)
        {
            Debug.Log(" while loop 2");
            int xWhile = almacenedWidth - 1;

            if (widthDiference < 0)
            {

                for (int y = 0; y < almacenedHeight; y++)
                {
                    DestroyTile(xWhile,y);
                }
                heightDiference++;
                almacenedWidth--;
                
            }
            else if (widthDiference > 0)
            {
                
                for (int y = 0; y < almacenedHeight; y++)
                {
                    CreateTileTemplate(xWhile +1, y);
                }
                almacenedWidth++;
                heightDiference--;
            }
        }


    }
    private void DestroyTile(int x, int y)
    {
        GameObject.DestroyImmediate(GetTileData(new Vector2(x, y)).gameObject);
    }

    private void SetTerrainData(float[,] noiseMap, TileProp tile, int x, int y)
    {
        foreach (NoiseToTerrain terrain in terrainMapings)
        {
            if (noiseMap[x, y] <= terrain.maxHeigth)
            {

                tile.terrain = terrain.terrain;
                tile.SpriteSync();
                break;

            }
        }
    }

    private void CreateTileTemplate(int x ,int y)
    {
        Vector3 tilePosition = new Vector3(x, y, 0);
        GameObject newTile = Instantiate(tileTemplate, tilePosition, Quaternion.identity, parentMap.transform);
        newTile.name = "New Tile";
        TileProp tileProp = newTile.GetComponent<TileProp>();
        almacenedTiles.Add(tileProp);
        tileProp.positionCoordinates = new Vector2(x, y);
    }

    private TileProp GetTileData(Vector2 coordinates)
    {
        foreach (TileProp tile in almacenedTiles)
        {

            if (tile.positionCoordinates.Equals(coordinates))
            {
                return tile;
            }

        }
        return null;
    }


    private void CreateMapMesh(int width, int height)
    {
        Vector3[] meshVertices = new Vector3[4]
        {new Vector3(0, 0, 0), new Vector3(width, 0, 0), new Vector3(0, height, 0), new Vector3(width, height, 0) };

        MeshGenerator.GenerateCuadMesh(parentMap, meshVertices);
    }


    private void UpdateTile(TileProp tileToUpdate, MapTerrain newTerrain)
    {
        tileToUpdate.terrain = newTerrain;
        tileToUpdate.SpriteSync();
    }


    public void CreateMapUsingNoiseMap(float[,] noiseMap, Vector2 offSet)
    {
 

        int width = noiseMap.GetLength(0);
        int heigth = noiseMap.GetLength(1);



        for (int y = 0; y < heigth; y++)
        {
            for (int x = 0; x < width; x++)
            {
                foreach (NoiseToTerrain terrain in terrainMapings)
                {
                    if (noiseMap[x, y] <= terrain.maxHeigth)
                    {
                       

                        Vector3 tilePosition = new Vector3(x + offSet.x,y + offSet.y , 0);
                        GameObject newTile = Instantiate(tileTemplate, tilePosition, Quaternion.identity, parentMap.transform);
                        newTile.name = terrain.terrain.ToString() + " tile";

                        TileProp tileProp = newTile.GetComponent<TileProp>();
                        tileProp.terrain = terrain.terrain;
                        tileProp.positionCoordinates = new Vector2(x, y);
                        tileProp.SpriteSync();

                       

                        break;

                    }
                }
            }
        }

        Vector3[] meshVertices = new Vector3[4]  
        {new Vector3(offSet.x, offSet.y,0), new Vector3(offSet.x + width, offSet.y, 0),
            new Vector3(offSet.x, offSet.y + heigth, 0), new Vector3(offSet.x + width, offSet.y + heigth, 0) };

        MeshGenerator.GenerateCuadMesh(parentMap, meshVertices);

    }


    public void DrawNoiseMap(float[,]noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D mapTexture = new Texture2D(width, height);
        Color[] colorMap = new Color[width * height];

        for (int y = 0, i = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++ , i++)
            {
                colorMap[i] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
            }
        }

        mapTexture.SetPixels(colorMap);
        mapTexture.Apply();

        textureRenderer.sharedMaterial.mainTexture = mapTexture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }


}

