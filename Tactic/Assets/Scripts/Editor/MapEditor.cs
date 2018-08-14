using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapEditor : Editor {

    public override void OnInspectorGUI()
    {
        
        
        MapGenerator thisMapGenerator = (MapGenerator)target;
        if (DrawDefaultInspector())
        {
            if (thisMapGenerator.autoUpdateInEditor)
            {
                if (thisMapGenerator.generationMode == MapGenerator.GenerationMode.ByTexture)
                {
                    thisMapGenerator.GenerateMapByTexture();
                }
                else if (thisMapGenerator.generationMode == MapGenerator.GenerationMode.Procedual)
                {
                    thisMapGenerator.GenerateMapWithNoiseMap();
                }
            }
        }

        if (GUILayout.Button("Generate!"))
        {
            if (thisMapGenerator.generationMode == MapGenerator.GenerationMode.ByTexture)
            {
                thisMapGenerator.GenerateMapByTexture();
            }
            else if (thisMapGenerator.generationMode == MapGenerator.GenerationMode.Procedual)
            {
                thisMapGenerator.GenerateMapWithNoiseMap();
            }
               
            
        }
       
    }

    /*Quiero que al estar en modo x, solo muestre las variables que seriven para ese metodo
     * 
     * 
     * 
    public override void OnInspectorGUI()
    {
        
        MapGenerator generator = (MapGenerator)target;
        generator.generationMode = EditorGUILayout.ObjectField(generator.generationMode, typeof(MapGenerator.GenerationMode),true;

        if (generator.generationMode == MapGenerator.GenerationMode.ByTexture)
        {
            generator.level = (Texture2D)EditorGUILayout.ObjectField(generator.level, typeof(Texture2D), true);
            

        }
        else if (generator.generationMode == MapGenerator.GenerationMode.Procedual)
        {

        }
    }
   */

}
