using NUnit.Framework.Constraints;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Terahedron : MonoBehaviour
{

    private void OnEnable()
    {
        var vertices = new Vector3[]
        {
            Vector3.zero,Vector3.right,Vector3.forward,new Vector3(0.5f,1,0.05f)
        };
        var triangles = new int[]
        {
            0,1,2,
            0,2,3,
            0,3,1
           ,3,2,1
        
        };
        var normals = new Vector3[]
        {
            Vector3.back,Vector3.back,Vector3.back,Vector3.back
        };
        var uv = new Vector2[]
        {
            new Vector2(0,0),Vector2.right,Vector2.up,new Vector2 (1,1)
        };
     
        var mesh = new Mesh
        {
            vertices = vertices,
            triangles = triangles,
           
            normals = normals,
            uv = uv,
            name = "Tetrahedron"
        };
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private void OnDrawGizmos()
    {
        var vertices = new Vector3[]
      {
                Vector3.zero,Vector3.right,Vector3.forward,new Vector3(0.5f,1,0.05f)
      };
        foreach (Vector3 v in vertices)
        {
            Gizmos.DrawSphere(v, 0.05f);
            
        }
    }
}

