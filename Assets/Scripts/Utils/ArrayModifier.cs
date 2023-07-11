using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ArrayModifier : MonoBehaviour
{
    public GameObject objectToArray;

    private Vector3 _lastPos; // 0,0,0

    public Vector3Int countOnVec;

    public void Apply()
    {
        // execute in edit mode
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            return;

        if (!objectToArray)
            return;

        // destroy all children before make new transform
        DestroyAllChildren();
        
        InitArray();
    }

    private void InitArray()
    {
        Renderer objRenderer = objectToArray.GetComponent<Renderer>();
        if (!objectToArray.GetComponent<Renderer>())
            return;
        
        for (int i = 0; i < 3; i++)
        {
            int addAmount = countOnVec[i];
            if (addAmount <= 0)
                continue;
            
            for (int j = 0; j < addAmount; j++)
            {
                Vector3 pos = _lastPos;
                pos[i] -= transform.localPosition[i]; // where to create new copy
                GameObject newCopy = Instantiate(objectToArray, pos, Quaternion.identity, transform);
                newCopy.name = objectToArray.name + '_' + (j + 1);
               _lastPos[i] += objRenderer.bounds.size[i]; // offset
            }
            _lastPos[i] = transform.localPosition[i]; // reset pos
        }
    }

    public void DestroyAllChildren()
    {
        if (!objectToArray.GetComponent<Renderer>())
            return;

        foreach (Transform t in transform)
            EditorApplication.delayCall += () => { DestroyImmediate(t.gameObject); };
    }
}
