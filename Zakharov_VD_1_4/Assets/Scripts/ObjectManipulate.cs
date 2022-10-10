using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulate : MonoBehaviour
{
    private GameObject _cube;
    private float _moveTime = 1f;
    private List<GameObject> primitveList = new List<GameObject>();


    public ObjectManipulate(GameObject cube)
    {
        this._cube = cube;
    }

    private IEnumerator MoveTo(Vector3 сhangePosition, float speed)
    {
        Vector3 startPosition = this._cube.transform.position;
        Vector3 endPosition = this._cube.transform.position + сhangePosition;
        float speedCoefficent = 2;
        float currentTime = 0f;
        speed /= speedCoefficent;
        while (currentTime < this._moveTime)
        {
            this._cube.transform.position = Vector3.Lerp(startPosition, endPosition, 1 - (this._moveTime - currentTime) / this._moveTime);
            currentTime += Time.deltaTime*speed;

            yield return null;
        }
        this._cube.transform.position = endPosition;
        GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Cube.transform.position = endPosition;
        primitveList.Add(Cube); 
    }

    public IEnumerator MoveOnWay(Vector3[] points, float waitTime, float speed)
    {
        foreach(Vector3 point in points)    
        {
            yield return MoveTo(point, speed);
            yield return new WaitForSeconds(waitTime);
        }
        foreach(GameObject cube in primitveList)
        {
            Destroy(cube);
        }
        yield return null;
    }
}
