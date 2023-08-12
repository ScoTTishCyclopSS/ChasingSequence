using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Weapons
{
    public class Hitscan : MonoBehaviour
    {
        [System.Serializable]
        private class AnimatedProperty
        {
            public string name;
            public float start;
            public float end;
            [HideInInspector] public int shaderProperty;
        }
        
        [Header("Damage")]
        [SerializeField] protected bool verticalSpread = true;
	    [SerializeField] protected bool horizontalSpread = true;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private LayerMask blockLayer;
        [SerializeField] private float width;
        [SerializeField] private int damage;
        
        [Header("Appearance")]
        [SerializeField] private LineRenderer lineRenderer;
        public float lifetime = 0.45f;
        [SerializeField] private List<AnimatedProperty> animatedProperties;
        private Material lineMaterial;
        //TODO implement [SerializeField] private Optional<string> hitVfx;
    
        private void Awake()
        {
            lineMaterial = lineRenderer.material;
            foreach (var animatedProperty in animatedProperties)
            {
                animatedProperty.shaderProperty = Shader.PropertyToID(animatedProperty.name);
            }
        }
    
        public virtual void OnFire(Vector3 forward, float Rand, float range = 100f)
        {
            Vector3 velocity = forward;
	    	if(verticalSpread) velocity += Random.Range(-Rand, Rand) * transform.up;
	    	if(horizontalSpread) velocity += Random.Range(-Rand, Rand) * transform.right;
    
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, width, velocity, SetUpRange(velocity, range),targetLayer);
            var list = new List<int>();
            foreach(RaycastHit hit in hits)
            {
                Hitable hitable = hit.collider.gameObject.GetComponentInParent<Hitable>();
    
                if(hitable != null)
                {
                    int hitID = hitable.GetInstanceID();
                    if(list.Contains(hitID)) continue;
                    list.Add(hitID);
                    
	    			hitable.Hit(damage);
                }
            }
    
            StartCoroutine(Disable());
        }
    
        private float SetUpRange(Vector3 forward, float range)
        {
            lineRenderer.SetPosition(0, transform.position);
            float maxPierceDistance;
            if(Physics.Raycast(transform.position, forward, out var blockHit, range, blockLayer))
            {
                maxPierceDistance = blockHit.distance;
                lineRenderer.SetPosition(1, blockHit.point);
    
            } else 
            {
                maxPierceDistance = range;
                lineRenderer.SetPosition(1, transform.position + forward * maxPierceDistance);
            }
    
            return maxPierceDistance;
        }

        private IEnumerator Disable()
        {
            var wait = new WaitForFixedUpdate();
            var endTime = Time.time + lifetime;
            var startTime = Time.time;
            while (Time.time < endTime)
            {
                var t = Mathf.InverseLerp(startTime, endTime, Time.time);
                foreach (var animatedProperty in animatedProperties)
                {
                    lineMaterial.SetFloat(animatedProperty.shaderProperty, Mathf.SmoothStep(animatedProperty.start, animatedProperty.end, t));
                }
                
                yield return wait;
            }
            yield return new WaitForSeconds(0.3f);
            gameObject.SetActive(false);
        }
    }
}