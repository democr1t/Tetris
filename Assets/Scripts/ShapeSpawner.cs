using UnityEngine;
using System.Collections.Generic;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private List<Shape> _prefabs;
    [SerializeField] private List<Shape> _shapes;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {  
        int randomIndex = Random.Range(0, _prefabs.Count);
        var shape = Instantiate(_prefabs[randomIndex], transform);
        shape.Stacked += OnShapeStacked;
        _shapes.Add(shape);
    }

    private void OnDisable()
    {
        foreach (var shape in _shapes)
        {
            shape.Stacked -= OnShapeStacked;
        }
    }

    private void OnShapeStacked()
    {
        Debug.Log("HERE");
        foreach (var shape in _shapes)
        {
            shape.Stacked -= OnShapeStacked;
        }
        Spawn();
    }
}
