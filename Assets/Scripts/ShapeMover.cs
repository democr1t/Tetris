using UnityEngine;
using System.Collections.Generic;

public class ShapeMover : MonoBehaviour
{
    [SerializeField] private float _moveTimer;

    private float _elapsedTime;
    private float _leftBound = -8;
    private float _rightBound = 8;
    private float _bottomBound = -4.5f;
    private List<Transform> _childrenSquares = new List<Transform>();
    private ShapeMover _shapeMover;

    private void Start()
    {
        FillChildrenSquares();
       _shapeMover = GetComponent<ShapeMover>();
    }

    void Update()
    {
        Down();
        Drag();
    }

    private void Down()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _moveTimer && CheckBottomBound())
        {
            transform.Translate(Vector2.down, Space.World);
            _elapsedTime = 0;
        }
    }

    private void Drag()
    {
        if (Input.GetKeyDown(KeyCode.A) && CheckLeftBound())
        {
            transform.Translate(Vector3.left, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.D) && CheckRightBound())
        {
            transform.Translate(Vector3.right, Space.World);       
        }
    }

    private bool CheckLeftBound()
    {
        bool result = true;

        for (int i = 0; i < _childrenSquares.Count; i++)
        {
            if (_childrenSquares[i].transform.position.x - 1 < _leftBound)
            {
                result = false;
            }  
        }

        return result;
    }

    private bool CheckRightBound()
    {
        bool result = true;

        for (int i = 0; i < _childrenSquares.Count; i++)
        {
            if (_childrenSquares[i].transform.position.x + 1 > _rightBound)
            {
                result = false;
                _shapeMover.enabled = false;
            }
        }  

        return result;
    }

    private bool CheckBottomBound()
    {
        bool result = true;

        for (int i = 0; i < _childrenSquares.Count; i++)
        {
            if (_childrenSquares[i].transform.position.y - 1 < _bottomBound)
            {
                result = false;
            }
        }

        return result;
    }

    private void FillChildrenSquares()
    {
        foreach (Transform child in transform)
        {
            _childrenSquares.Add(child);
        }
    }
}
