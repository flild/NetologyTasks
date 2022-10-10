using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeManipulate : MonoBehaviour
{
    private static float sideSize = 2;
    [SerializeField] private GameObject _cube;

    private Vector3[] _squareWay =
    {
        new Vector3(sideSize, 0, 0),
        new Vector3(0, 0, sideSize),
        new Vector3(-sideSize, 0, 0),
        new Vector3(0, 0, -sideSize)
    };

    private Vector3[] _triangleWay =
{
        new Vector3(-sideSize*2, 0, 0),
        new Vector3(sideSize, 0, sideSize),
        new Vector3(sideSize, 0, -sideSize)

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

            yield return CubeMover.MoveOnWay(_squareWay);
            yield return new WaitForSeconds(1f);
            yield return CubeMover.MoveOnWay(_triangleWay);
            yield return new WaitForSeconds(1f);
        }

    }
}
