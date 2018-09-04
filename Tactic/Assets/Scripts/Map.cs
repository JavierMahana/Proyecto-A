using UnityEngine;


public class Map {

    public Map(ref Texture2D level, ref ColorToTerrain[] colorMapings)
    {
       
        Generate(ref level, ref colorMapings);
    }

    
    Tile[,] map;

    public Tile GetTile(int x, int y)
    {
        return map[x, y];
    }


    void Generate(ref Texture2D level, ref ColorToTerrain[] colorMapings)
    {
        

        int xSize = level.width;
        int ySize = level.height;

        MapTerrain[] data = GetMapData(ref level, ref colorMapings, xSize, ySize);
        GenerateTiles(data, xSize, ySize);

    }

    

    /// <summary>
    /// Each pixel in the texture represents the data of a tile
    /// </summary>
    /// <param name="sourceImage"></param>
    /// <returns></returns>
    MapTerrain[] GetMapData(ref Texture2D level, ref ColorToTerrain[] colorMapings, int xSize, int ySize)
    {

        MapTerrain[] mapData = new MapTerrain[xSize * ySize];
        for (int y = 0, i = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++, i++)
            {
                Color pixelColor = level.GetPixel(x, y);

                Debug.Log(pixelColor.ToString());

                mapData[i] = GetTerrainFromColor(pixelColor, ref colorMapings);
                
            }
        }
        return mapData;
    }

    /// <summary>
    /// To generate the map
    /// </summary>
    /// <param name="mapData">the info array has this first value for the bottom left of the map</param>
    void GenerateTiles(MapTerrain[] mapData, int xSize, int ySize)
    {
        map = new Tile[xSize,ySize];
        for (int y = 0, i = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++, i++)
            {
                map[x, y] = new Tile(mapData[i], x, y);
                //Debug.Log(GetTile(x, y).terrain_.name + " " + GetTile(x, y).x_.ToString() + "/" + GetTile(x, y).y_.ToString());
            }
        }
    }

    
    

    
   

    /// <summary>
    /// You give a color and it returns the terrain that represents
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    MapTerrain GetTerrainFromColor(Color color, ref ColorToTerrain[] references)
    {
        if (color.a != 1)
        {
            Debug.LogWarning("The pixel color have an alpha value that is not 1");
            return null;
        }


        foreach (ColorToTerrain colorMapping in references)
        {
            if (colorMapping.color.Equals(color))
            {
                //match
                return colorMapping.terrain;
            }
        }
        Debug.LogWarning(color.ToString() + "The pixel color doesnt match any of the presets!");
        return null;

    }

    
}
