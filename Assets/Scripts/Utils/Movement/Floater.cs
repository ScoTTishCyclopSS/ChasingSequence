using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private float startPos;
    private float speed;
    public float rotSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float range = 0.25f;
    [SerializeField] private bool rotating = true;
    private void Start()
    {
        startPos = transform.localPosition.y;
        speed = 0;
        StartCoroutine(SpeedUp());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, startPos + Mathf.Sin(Time.time * speed)*range, transform.localPosition.z);

        if(rotating) transform.RotateAround(transform.position, new Vector3(0,1,0), speed);
    }

    private IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
        speed = rotSpeed;
    }

    private void OnDisable()
    {
        rb.useGravity = true;
        this.enabled = false;
    }
}
