using UnityEngine;

public class QuadNormal : MonoBehaviour
{



    private void OnEnable()
    {
        var vertices = new Vector3[]
        {
            Vector3.zero,Vector3.right,Vector3.up,new Vector3(1,1,0)
        };
        var triangles = new int[]
        {
            0,2,1,2,3,1
        };
        var normals = new Vector3[]
        {
            Vector3.back,Vector3.back,Vector3.back,Vector3.back
        };
        var uv = new Vector2[]
        {
            new Vector2(0,0),Vector2.right,Vector2.up,new Vector2 (1,1)
        };
        var tangents = new Vector4[]
        {
            new Vector4 (1,0,0,1),  new Vector4 (1,0,0,1),  new Vector4 (1,0,0,1),  new Vector4 (1,0,0,1)
        };
        var mesh = new Mesh
        {
            vertices = vertices,
            triangles = triangles,
            tangents = tangents,
            normals = normals,
            uv = uv,
            name = "Quad"
        };
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
