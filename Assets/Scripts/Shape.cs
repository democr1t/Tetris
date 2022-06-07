using UnityEngine;
using UnityEngine.Events;

public class Shape : MonoBehaviour
{
    private ShapeMover _mover;
    private ShapeRotator _rotator;
    private ShapeSquare _shapeSquare;

    public event UnityAction Stacked;

    private void Start()
    {
         _mover = GetComponent<ShapeMover>();
        _rotator = GetComponent<ShapeRotator>();

        foreach (Transform child in transform)
        {
            _shapeSquare = child.GetComponent<ShapeSquare>();
            _shapeSquare.Stacked += OnSquaresStacked;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("ITS WORKS");
    //    Stacked?.Invoke();

    //}

    private void OnSquaresStacked()
    {
        foreach (Transform child in transform)
        {
            _shapeSquare = child.GetComponent<ShapeSquare>();
            _shapeSquare.Stacked -= OnSquaresStacked;
        }

        _rotator.enabled = false;
        _mover.enabled = false;
        Stacked?.Invoke();
        
    }
}
