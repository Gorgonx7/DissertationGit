﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Legacy code for combining multiple meshes into one
/// </summary>
public class MeshCombiner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshFilter filter;
        MeshRenderer renderer;
        List<Mesh> childMeshs = new List<Mesh>();
        filter = GetComponent<MeshFilter>();
        if (filter != null)
        {
            childMeshs.Add(GetComponent<MeshFilter>().mesh);
        }
        else
        {
            filter = gameObject.AddComponent<MeshFilter>();
            renderer = gameObject.AddComponent<MeshRenderer>();

        }
        MeshFilter[] childRenders = GetComponentsInChildren<MeshFilter>();
        
        foreach(MeshFilter i in childRenders)
        {
            childMeshs.Add(i.mesh);
           // i.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        Mesh outputmesh = CombineMeshes(childMeshs);
        outputmesh.name = "Combinedmesh";
        filter.mesh = outputmesh;
        

    }

   
    private Mesh CombineMeshes(List<Mesh> meshes)
    {
        var combine = new CombineInstance[meshes.Count];
        for (int i = 0; i < meshes.Count; i++)
        {
            combine[i].mesh = meshes[i];
            combine[i].transform = transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        return mesh;
    }
}
