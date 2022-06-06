using UnityEngine;

public class ShapeRotator : MonoBehaviour
{
    private Vector3 _rightAngle = new Vector3(0, 0, 90);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.RotateAround(transform.position, _rightAngle, 90);
        }
    }
}
