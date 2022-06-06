using UnityEngine;
using UnityEngine.Events;

public class Shape : MonoBehaviour
{
    private ShapeMover _shapeMover;
    public event UnityAction Stacked;

    private void Start()
    {
         _shapeMover = GetComponent<ShapeMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ITS WORKS");
        Stacked?.Invoke();
        _shapeMover.enabled = false;
    }
}
