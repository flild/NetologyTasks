using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCubeManipulator : MonoBehaviour
{
    [SerializeField] private float sideSize;
    [SerializeField] private GameObject _cube;

    private void Start()
    {
        StartCoroutine(MoveOncurrentWay());
    }
    private IEnumerator MoveTo(Vector3 сhangePosition, float time)
    {
        Vector3 startPosition = _cube.transform.position;
        Vector3 endPosition = _cube.transform.position + сhangePosition;

        float currentTime = 0f;
        while (currentTime < time)
        {
            _cube.transform.position = Vector3.Lerp(startPosition, endPosition, 1 - (time - currentTime) / time);
            currentTime += Time.deltaTime;

            yield return null;
        }
        _cube.transform.position = endPosition;
    }

    private IEnumerator MoveStarWay()
    {
        float delay = 1f;
        yield return MoveTo(new Vector3(sideSize / 2, 0, sideSize), delay);
        yield return MoveTo(new Vector3(sideSize / 2, 0, -sideSize), delay);
        yield return MoveTo(new Vector3(-sideSize, 0, sideSize / 2), delay);
        yield return MoveTo(new Vector3(sideSize, 0, 0), delay);
        yield return MoveTo(new Vector3(-sideSize, 0, -sideSize / 2), delay);
        yield return null;
    }

    private IEnumerator MoveHexagonWay()
    {
        float delay = 1f;
        yield return MoveTo(new Vector3(-sideSize, 0, 0), delay);
        yield return MoveTo(new Vector3(-sideSize / 3, 0, sideSize / 2), delay);
        yield return MoveTo(new Vector3(sideSize / 3, 0, sideSize / 2), delay);
        yield return MoveTo(new Vector3(sideSize, 0, 0), delay);
        yield return MoveTo(new Vector3(sideSize / 3, 0, -sideSize / 2), delay);
        yield return MoveTo(new Vector3(-sideSize / 3, 0, -sideSize / 2), delay);
        yield return null;
    }

    private IEnumerator MoveOncurrentWay()
    {
        while (true)
        {

            yield return MoveStarWay();
            yield return new WaitForSeconds(1f);
            yield return MoveHexagonWay();
            yield return new WaitForSeconds(1f);
        }

    }
}
