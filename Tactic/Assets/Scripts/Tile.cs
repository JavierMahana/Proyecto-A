using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile  {

    public Tile(MapTerrain terrain, int x, int y)
    {
        terrain_ = terrain;
        x_ = x;
        y_ = y;
    }

    public MapTerrain terrain_ { get; private set; }

    public int x_{ get; private set; }
    public int y_ { get; private set; }

    public bool isOcupied_;
    public bool ocupiedByEnemy_;

    
}
