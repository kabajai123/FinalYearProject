using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[RequireComponent(typeof(MeshFilter))]
public class CreateRoadMeshRealTime : MonoBehaviour
{

    Mesh mesh;
    Vector3[] AllKey;
    public string AssetPath;

    public Quaternion Rotate;
    public Vector3 NowPos;
    public GameObject Camea; // camera
    public GameObject PrefabRoad;
    public List<Vector3> KeyPoint = new List<Vector3>();
    public List<Vector3> getVector = new List<Vector3>();
    List<int> triangles = new List<int>();

    public int KeyPointCount=0;
    // Start is called before the first frame update
    void Start()
    {
   
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; // CreateMesh();
        Vector3 Pos = Camea.transform.position;
        KeyPoint.Add(Camea.transform.position);
        getVector.Add(new Vector3(Pos.x + 1, 499.8f, Pos.z));// 1,0,0
        getVector.Add(new Vector3(Pos.x - 1, 499.8f, Pos.z));//-1,0,0
        getVector.Add(new Vector3(Pos.x + 1, 499.7f, Pos.z));// 1,-0.01,0
        getVector.Add(new Vector3(Pos.x - 1, 499.7f, Pos.z));//-1,-0.01,0
        //GameObject Road =Instantiate(PrefabRoad, Camea.transform.position, Quaternion.identity);
        Rotate = Camea.transform.rotation;

        Debug.Log("angle "+Vector3.Angle(new Vector3(1,0,0), new Vector3(-1,0,0)));

    }
    void Update()
    {
        NowPos = Camea.transform.position;
        if ((Rotate != Camea.transform.rotation) && (getVector[getVector.Count-1] != new Vector3(Camea.transform.position.x-1, Camea.transform.position.y - 0.01f, Camea.transform.position.z))) {
            Rotate = Camea.transform.rotation;
            Vector3 Pos = Camea.transform.position;
            KeyPoint.Add(Camea.transform.position);
            getVector.Add(new Vector3(Pos.x + 1, 499.8f, Pos.z));
            getVector.Add(new Vector3(Pos.x - 1, 499.8f, Pos.z));
            getVector.Add(new Vector3(Pos.x + 1, 499.7f, Pos.z));
            getVector.Add(new Vector3(Pos.x - 1, 499.7f, Pos.z));
            KeyPointCount++;
            CreateMesh();
        }



    }
   
    
    void CreateMesh()
    {
        mesh.Clear();
        List<int> triangles = new List<int>();
        for (int count = 0; count < getVector.Count - 4; count++)
        {
                triangles.Add(count);
                triangles.Add(count + 1);
                triangles.Add(count + 4);
                count++;
                triangles.Add(count + 3);
                triangles.Add(count);
                triangles.Add(count + 4);
                count++;
                triangles.Add(count + 1);
                triangles.Add(count);
                triangles.Add(count + 5);
                count++;
                triangles.Add(count + 4);
                triangles.Add(count - 1);
                triangles.Add(count + 3);
        }

        mesh.vertices = getVector.ToArray();
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