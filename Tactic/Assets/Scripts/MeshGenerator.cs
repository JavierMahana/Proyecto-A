using UnityEngine;

public static class MeshGenerator {


    public static void GenerateCuadMesh(GameObject rendererColliderContainer, 
        Vector3 bottomLeft, Vector3 topLeft, Vector3 bottomRight, Vector3 topRight)
    {
        MeshCollider collider = rendererColliderContainer.GetComponent<MeshCollider>();
        MeshFilter filter = rendererColliderContainer.GetComponent<MeshFilter>();

        Mesh newMesh = new Mesh();

        Vector3[] vertices = new Vector3[4] {bottomLeft, bottomRight, topLeft, topRight};
        int[] triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = triangles[4] = 2;
        triangles[2] = triangles[3] = 1;
        triangles[5] = 3;

        newMesh.vertices = vertices;
        newMesh.triangles = triangles;

        filter.sharedMesh = newMesh;
        collider.sharedMesh = newMesh;

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rendererColliderContainer"></param>
    /// <param name="vertices">left/rigth bottom/up</param>
    public static void GenerateCuadMesh(GameObject rendererColliderContainer, Vector3[]vertices)
    {
        MeshCollider collider = rendererColliderContainer.GetComponent<MeshCollider>();
        MeshFilter filter = rendererColliderContainer.GetComponent<MeshFilter>();

        Mesh newMesh = new Mesh();

        
        int[] triangles = new int[6];

        triangles[0] = 0;
        triangles[1] = triangles[4] = 2;
        triangles[2] = triangles[3] = 1;
        triangles[5] = 3;

        newMesh.vertices = vertices;
        newMesh.triangles = triangles;
        

        filter.sharedMesh = newMesh;
        collider.sharedMesh = newMesh;
        

    }



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
