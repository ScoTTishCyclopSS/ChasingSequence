using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField] private float range = 0.25f;
    [SerializeField]private float speed;
    private float _startPos;
    
    
    private void Start()
    {
        _startPos = transform.localPosition.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var localPos = transform.localPosition;
        transform.localPosition =
            new Vector3(localPos.x, _startPos + Mathf.Sin(Time.time * speed) * range, localPos.z);
    }
}