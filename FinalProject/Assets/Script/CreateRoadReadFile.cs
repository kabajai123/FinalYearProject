using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter))]
public class CreateRoadReadFile : MonoBehaviour
{
    Mesh mesh;
    Vector3 g_camerpos;
    public string AssetPath;
    GameFunction gameFunction;
    List<Vector3> keyframe;
    TextAsset txtAsset;
    // Start is called before the first frame update
    void Start()
    {
        txtAsset = Resources.Load<TextAsset>(AssetPath);

        gameFunction = GetComponent<GameFunction>();
        g_camerpos = new Vector3(500,499.9f,500);
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        keyframe = new List<Vector3>();


        CreateMesh();

    }

    void CreateMesh()
    {
        mesh.Clear();
        List<int> triangles = new List<int>();
        for (int count = 0; count < ReadFile().Count - 2; count++)
        {
            triangles.Add(count);
            triangles.Add(count + 1);
            triangles.Add(count + 2);
            count++;
            triangles.Add(count + 1);
            triangles.Add(count);
            triangles.Add(count + 2);

        }

        mesh.vertices = ReadFile().ToArray();
        mesh.triangles = triangles.ToArray();
        gameFunction.SpawnItemAndStart(keyframe);
    }
    Vector3[] StartEnd;
    List<Vector3> ReadFile()
    {
        keyframe.Clear();
        //StreamReader reader = new StreamReader(AssetPath);
        string txtstring = txtAsset.text;

        float x = 0, y = 0, z = 0;
        List<Vector3> getVector = new List<Vector3>();
        string[] reader = txtstring.Split('\n');
        

        for (int i =0; i< reader.Length-1;i++)
        {
            string[] line = new string[8];
            line = reader[i].Split(' ');
            x = float.Parse(line[1]);
            y = float.Parse(line[2]);
            z = float.Parse(line[3]);
            getVector.Add(new Vector3(x + 0.1f, 0, z) * 100 + g_camerpos);
            getVector.Add(new Vector3(x - 0.1f, 0, z) * 100 + g_camerpos);
            keyframe.Add(new Vector3(x, 0, z)*100+g_camerpos);

        }
        


        return getVector;
    }
    // Update is called once per frame
    void Update()
    {

    }
}