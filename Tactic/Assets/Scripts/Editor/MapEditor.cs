using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapGenerator thisMapGenerator = (MapGenerator)target;

        if (GUILayout.Button("Generate!"))
        {
            thisMapGenerator.Generate();
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
