using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FragmentLoader : MonoBehaviour
{
    public List<GameObject> fragments;
    
    void SetupLayerCollisions() //layers shall only collide with themselves
    {
        for (int i = 0; i < 20; i++)
        {
            Physics2D.SetLayerCollisionMask(i, (1 << i));
        }
    }

    void LoadFragment(string fname) // load each fragment for a given problem
    {
        GameObject frag = new GameObject();
        frag.name = "fragment";
        PolygonCollider2D poly = frag.AddComponent<PolygonCollider2D>();

        frag.layer = 10;

        Rigidbody2D rig = frag.AddComponent<Rigidbody2D>();
        rig.gravityScale = 0;

        fragments.Add(frag);

        //load polygon

        StreamReader reader = new StreamReader(fname);
        string data = reader.ReadToEnd();

        List<Vector2> polyShape = new List<Vector2>();
        foreach (string line in data.Split("\n"))
        {
            if (line.Contains("\t"))
            {
                string[] split = line.Split("\t");

                int x = int.Parse(line.Split("\t")[0]);
                int y = int.Parse(line.Split("\t")[1]);
                polyShape.Add(new Vector2(x/1000, y/1000));
            }
        }
        poly.points = polyShape.ToArray();
    }

    void CreateBatch() // once we have the fragments loaded, we can create simulation batches
    {

    }
    
    void Start()
    {
        SetupLayerCollisions();
        LoadFragment("Data/train/1/387.txt");
    }

    void Update()
    {
        
    }
}
