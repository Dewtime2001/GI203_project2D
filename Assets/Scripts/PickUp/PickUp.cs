using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public bool alwaysAnimate = false;
    public Vector3 rotationRate = new Vector3(0, 90, 0);

    private Renderer r;
    
    public virtual void Start()
    {
        r = GetComponent<Renderer>();
    }

    
    public virtual void Update()
    {
        if (!alwaysAnimate && r && !r.isVisible)
        {
            return;
        }

        if (rotationRate.sqrMagnitude > 0)
        {
            transform.Rotate(rotationRate * Time.deltaTime);
        }
    }
}
