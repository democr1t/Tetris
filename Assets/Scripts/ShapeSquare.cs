using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShapeSquare : MonoBehaviour
{
    private ShapeMover _shapeMover;
    public event UnityAction Stacked;

    private void Start()
    {
        _shapeMover = GetComponentInParent<ShapeMover>();
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Shape>() != gameObject.GetComponentInParent<Shape>())
        {
            Stacked?.Invoke();
           // _shapeMover.enabled = false;
        }
    }
}
