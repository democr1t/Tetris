using UnityEngine;

public class ShapeRotator : MonoBehaviour
{
    private Vector3 _rightAngle = new Vector3(0, 0, 90);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(_rightAngle);
        }
    }
}
