using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulate : MonoBehaviour
{
    private GameObject _cube;
    private float _moveTime = 1f;

    public ObjectManipulate(GameObject cube)
    {
        this._cube = cube;
    }

    private IEnumerator MoveTo (Vector3 сhangePosition)
    {
        Vector3 startPosition = this._cube.transform.position;
        Vector3 endPosition = this._cube.transform.position + сhangePosition;

        float currentTime = 0f;
        while (currentTime < this._moveTime)
        {
            this._cube.transform.position = Vector3.Lerp(startPosition, endPosition, 1 - (this._moveTime - currentTime) / this._moveTime);
            currentTime += Time.deltaTime;

            yield return null;
        }
        this._cube.transform.position = endPosition;
    }

    public IEnumerator MoveOnWay(Vector3[] points)
    {
        foreach(Vector3 point in points)
        {
            yield return MoveTo(point);
        }
        yield return null;
    }
}
