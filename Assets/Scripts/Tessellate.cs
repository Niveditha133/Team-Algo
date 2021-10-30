using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tessellate : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        MeshFilter meshfilter = GetComponent<MeshFilter>();
        Mesh mesh = meshfilter.mesh;

        //vertices
        Vector3[] vertices = new Vector3[]
        {
            //cube
            //frontside
            new Vector3(-1, 1, 1), //right top front, 0
            new Vector3(1, 1, 1), //left top front, 1
            new Vector3(-1, -1, 1), //right bottom front, 2
            new Vector3(1, -1, 1), //left bottom front, 3

            //backface
            new Vector3(1, 1, -1), //right top front, 4
            new Vector3(-1, 1, -1), //left top front, 5
            new Vector3(1, -1, -1), //right bottom front, 6
            new Vector3(-1, -1, -1), //left bottom front, 7

            //leftface
            new Vector3(-1, 1, -1), //right top front, 8
            new Vector3(-1, 1, 1), //left top front, 8
            new Vector3(-1, -1, -1), //right bottom front, 10
            new Vector3(-1, -1, 1), //left bottom front, 11

            //right face
            new Vector3(1, 1, 1), //right top front, 12
            new Vector3(1, 1, -1), //left top front, 13
            new Vector3(1, -1, 1), //right bottom front, 14
            new Vector3(1, -1, -1), //left bottom front, 15

            //top face
            //left top back, 16
            //right top back, 17
            //
        };

        //triangle //3 points, clockwise determines which side in visible
        int[] triangles = new int[]
        {
            //front face
            0,2,3, //first triangle
            3,1,0 //second triangle
        };

        //UVs
        Vector2[] uvs = new Vector2[]
        {
            //front face // 0,0 is bottom left, 1,1 is top right
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2 (1,0)
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}