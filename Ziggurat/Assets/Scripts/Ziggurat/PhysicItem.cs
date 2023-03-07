using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Ziggurat
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Ziggurat _ziggurat;
        [Inject]
        private UIManager _UIManager;
        private void Start()
        {
            _ziggurat = GetComponent<Ziggurat>();
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            CleanAllZigguratCanvas();
            _UIManager.zigguratSettings[_ziggurat.color].gameObject.SetActive(true);
        }

        private void CleanAllZigguratCanvas()
        {
            foreach(var canvas in _UIManager.zigguratSettings)
            {
                Debug.Log(canvas.Value.gameObject.name);
                canvas.Value.gameObject.SetActive(false);
            }
        }
    }
}

