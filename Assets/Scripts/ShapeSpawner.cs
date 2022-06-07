using UnityEngine;
using System.Collections.Generic;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private List<Shape> _prefabs;
    [SerializeField] private List<ShapeSquare> _shapeSquares;

    private ShapeSquare _shapeSquare;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {  

        int randomIndex = Random.Range(0, _prefabs.Count);
        var shape = Instantiate(_prefabs[randomIndex], transform);
        shape.Stacked += OnShapeStacked;
        //foreach  (Transform childSquare in shape.transform)
        //{
        //    _shapeSquare = childSquare.gameObject.GetComponent<ShapeSquare>();
        //    _shapeSquare.Stacked += OnShapeStacked;
        //}
    }

    private void OnDisable()
    {
        foreach (var shapeSquare in _shapeSquares)
        {
            shapeSquare.Stacked -= OnShapeStacked;
        }
    }

    private void OnShapeStacked()
    {
        foreach (var shape in _shapeSquares)
        {
            shape.Stacked -= OnShapeStacked;
        }

        Spawn();
    }
}
