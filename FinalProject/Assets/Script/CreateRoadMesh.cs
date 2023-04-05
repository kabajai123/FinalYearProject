using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter))]
public class CreateRoadMesh : MonoBehaviour
{

    Mesh mesh;
    Vector3[] AllKey;
    public string AssetPath;

    
    public GameObject Main;
    public GameObject PrefabRoad;
    List<Vector3> getVector = new List<Vector3>();
    List<int> triangles = new List<int>();

    public int KeyPointCount=0;
    // Start is called before the first frame update
    void Start()
    {
   
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; // CreateMesh();

        getVector.Add(Main.transform.position);// 0,0,0
        //GameObject Road =Instantiate(PrefabRoad, Main.transform.position, Quaternion.identity);
        
    }
    void Update()
    {
        if (Vector3.Distance(getVector[getVector.Count - 1], Main.transform.position)>0.5f) {
            GameObject myPreFab = Instantiate(PrefabRoad,Main.transform.position, Quaternion.identity) as GameObject;
            myPreFab.transform.parent = transform;
            getVector.Add(Main.transform.position);//add new key point each 
            KeyPointCount++;
        }
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

    }

    List<Vector3> ReadFile()
    {
        StreamReader reader = new StreamReader(AssetPath);
        float x = 0, y = 0, z = 0;
        List<Vector3> getVector = new List<Vector3>();

        while (!reader.EndOfStream)
        {
            string[] line = reader.ReadLine().Split(' ');
            x = float.Parse(line[1]);
            y = float.Parse(line[2]);
            z = float.Parse(line[3]);
            getVector.Add(new Vector3(( x + 0.1f ) * 10, -1, (z + 0.1f) * 10));
            getVector.Add(new Vector3((x-0.1f)*10, -1, (z+0.1f)*10));

        }
        reader.Close();
        return getVector;
    }
    // Update is called once per frame
    
}