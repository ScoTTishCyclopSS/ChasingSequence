using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Treadmill : MonoBehaviour
{
    public Transform goalTransform;

    public float speed = 1.0f;

    private float _startTime;

    private Vector3 _startPos;
    
    private Vector3 _endPos;

    private List<Transform> _children;

    private const int Leader = 1;

    private float _journeyLength;

    private Vector3 mesh_offset;

    void Start()
    {
        // save time
        _startTime = Time.time;
        // create a list of children
        _children = GetComponentsInChildren<Transform>().ToList();

        // the end of journey
        _endPos = new Vector3(0.0f, 0.0f, goalTransform.position.z);
        // start pos of leader
        _startPos = _children[Leader].position;

        // the whole lenght to move
        _journeyLength = Vector3.Distance(_startPos, _endPos);
        
        // define offset by mesh
        Renderer r = _children[1].GetComponent<Renderer>();
        mesh_offset = new Vector3(0.0f, 0.0f, r.bounds.size[2]);
    }

    void Update()
    {
        float distCovered = (Time.time - _startTime) * speed;
        float fractionOfJourney = distCovered / _journeyLength;
        
        Vector3 oldLeadPos = _children[Leader].position;
        Vector3 newLeadPos = Vector3.Lerp(_startPos, _endPos, fractionOfJourney);
        Vector3 offset = newLeadPos - oldLeadPos;

        for (int i = Leader; i < _children.Count; i++)
        {
            _children[i].position += offset;
        }
        SendLeaderBack();
    }

    void SendLeaderBack()
    {
        if (_children[Leader].position == _endPos)
        {
            Transform leader = _children[Leader]; // take leader
            _children.RemoveAt(1); // remove him from list

            leader.position = _children.Last().position + mesh_offset; // move him back
            _children.Add(leader); // push to the end of children list
            
            _startTime = Time.time; // reset time
            _startPos = _children[Leader].position; // define new start pos
        }
    }
}