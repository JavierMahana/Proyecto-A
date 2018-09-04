using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileProp : MonoBehaviour {

    public void SpriteSync()
    {
        SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = terrain.visual;
    }

    private void Start()
    {
        SpriteSync();
        
    }

    public MapTerrain terrain;

    public Vector2 positionCoordinates;

    
}
