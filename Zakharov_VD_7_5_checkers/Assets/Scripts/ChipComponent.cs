using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Checkers
{
    public class ChipComponent : BaseClickComponent
    {

        public override void OnPointerEnter(PointerEventData eventData)
        {
            Pair.SetMaterial(currentCell);
            CallBackEvent((CellComponent)Pair, true);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            Pair.SetMaterial();
            CallBackEvent((CellComponent)Pair, false);
        }
        public void KillChip()
        {
            //удаляем эту фишку из пары клетки в которой она стояла
            Pair.Pair = null;
            Debug.Log(Pair +" "+ Pair.Pair);
            Destroy(gameObject);
        }
    }
}
