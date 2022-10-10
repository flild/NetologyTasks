using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeCubeManipulator : MonoBehaviour
{
    private static float sideSize = 3;
    [SerializeField] private GameObject _cube;

    private Vector3[] _starWay =
    {
        new Vector3(sideSize / 2, 0, sideSize),
        new Vector3(sideSize / 2, 0, -sideSize),
        new Vector3(-sideSize, 0, sideSize / 2),
        new Vector3(sideSize, 0, 0),
        new Vector3(-sideSize, 0, -sideSize / 2)
    };

    private Vector3[] _hexagonWay =
{
        new Vector3(-sideSize, 0, 0),
        new Vector3(-sideSize / 3, 0, sideSize / 2),
        new Vector3(sideSize / 3, 0, sideSize / 2),
        new Vector3(sideSize, 0, 0),
        new Vector3(sideSize / 3, 0, -sideSize / 2),
        new Vector3(-sideSize / 3, 0, -sideSize / 2)
    };


    private void Start()
    {
        ObjectManipulate CubeMover = new ObjectManipulate(_cube);
        StartCoroutine(MoveOncurrentWay(CubeMover));

    }


    private IEnumerator MoveOncurrentWay(ObjectManipulate CubeMover)
    {
        while (true)
        {

            yield return CubeMover.MoveOnWay(_starWay);
            yield return new WaitForSeconds(1f);
            yield return CubeMover.MoveOnWay(_hexagonWay);
            yield return new WaitForSeconds(1f);
        }

    }
}
