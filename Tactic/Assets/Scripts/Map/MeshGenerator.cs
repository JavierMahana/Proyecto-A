using UnityEngine;

public class MeshGenerator : MonoBehaviour {
    //REdo Total
    //Arreglar el tema de los sprites y texturas 2D
    //cambiar los sprites a texturas 2d
    //mejor a materiales

        //Cambio Total!!!

        //mañana revertire el sistema de creacion del mapa
        //seran simples sprites
/*
        /// <summary>
        /// Crea un mesh para pasarselo al mapa
        /// </summary>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <param name="map">Map Data</param>
    public void GenerateMapMeshes(int xSize, int ySize, Map map)
    {
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                
                GameObject tile = new GameObject(x.ToString() + "|" + y.ToString() + "Mesh");
                tile.transform.SetParent(this.transform); 

                Mesh newMesh = tile.AddComponent<MeshFilter>().mesh;
                


                Vector3[] vertices = new Vector3[4];

                
                





                tile.AddComponent<MeshRenderer>().material = map.GetTile(x,y).terrain_.visual;



            }
        }
    }
    */
    /*
    public static Mesh GenerateMesh(int xSize, int ySize)
    {
        
        Mesh mesh = new Mesh();
        mesh.name = "Procedual Grid";


        //vertices
        Vector3[] vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        //uv coordinates
        Vector2[] uv = new Vector2[vertices.Length];

        //setting the vertices and the uv coordinates
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        /*
         * el vi o vector index se aumenta en los dos for, ya que al subir de "y" la esquina
         * inferior derecha no es necesaria y se asalta.
         * vi = vector index
         * ti = triangle index
         * 
         * cada triangulo indica las 3 vertices que le corresponden
        
        int[] triangles = new int[xSize * ySize * 6];
        for (int y = 0, vi = 0, ti = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 1] = triangles[ti + 4] = vi + xSize + 1;
                triangles[ti + 2] = triangles[ti + 3] = vi + 1;
                triangles[ti + 5] = vi + xSize + 2;


            }

        }
        /*
         * Lo de arriba es una generalización de esto
         * esto es generar un cuadrado
        triangles[0] = 0;
        triangles[1] = triangles[4] = xSize + 1;
        triangles[2] = triangles[3] = 1;
        triangles[3] = 1;
        triangles[4] = xSize + 1;
        triangles[5] = xSize + 2;

        mesh.triangles = triangles;


        return mesh;
    }
    */
}
