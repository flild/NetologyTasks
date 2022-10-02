using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Сфера изменяет размер по всем осям со скоростью 1.5 единицы в секунду;
//Куб перемещается из положения по оси Z со скоростью 2 единицы в секунду;
//Цилиндр вращается вокруг своей оси X со скоростью -5 градусов в секунду;
public class FigureManager : MonoBehaviour
{
    [SerializeField] private bool _isSphereScale;
    [SerializeField] private bool _isCubeMove;
    [SerializeField] private bool _isCylinderRotate;
    [SerializeField] private GameObject _cylinder;
    [SerializeField] private GameObject _sphere;
    [SerializeField] private GameObject _cube;

    private Vector3 sphereScale = new Vector3(1.5f,1.5f,1.5f);
    private Vector3 cubePosition = new Vector3(0, 0, 2);
    private Vector3 cylinderRotation = new Vector3(-5,0,0);

    void Update()
    {
        if (_isSphereScale)
            _sphere.transform.localScale += sphereScale * Time.deltaTime;
        if (_isCubeMove)
            _cube.transform.position += cubePosition * Time.deltaTime;
        if (_isCylinderRotate)
            _cylinder.transform.eulerAngles += cylinderRotation * Time.deltaTime;
    }

}
