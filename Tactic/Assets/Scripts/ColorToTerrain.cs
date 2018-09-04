using UnityEngine;

[CreateAssetMenu(menuName = "Terrain/Color To Terrain")]
public class ColorToTerrain : ScriptableObject {

    
    public MapTerrain terrain;
    public Color color = new Color(0,0,0,1);

}
