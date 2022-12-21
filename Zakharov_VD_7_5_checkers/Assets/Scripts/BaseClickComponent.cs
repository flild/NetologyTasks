using System.Linq;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Checkers
{
    public abstract class BaseClickComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] public Material whiteCellMaterial;
        [SerializeField] public Material blackCellMaterial;
        [SerializeField] public Material whiteChipMaterial;
        [SerializeField] public Material blackChipMaterial;
        [SerializeField] public Material currentCell;
        

        protected MeshRenderer _meshRenderer;
        [Tooltip("Цветовая сторона игрового объекта"), SerializeField]
        public ColorType color;
        public bool isFreeToMove = false;
        private Material _defaultMaterial;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        /// <summary>
        /// Возвращает цветовую сторону игрового объекта
        /// </summary>
        public ColorType GetColor => color;

        /// <summary>
        /// Возвращает или устанавливает пару игровому объекту
        /// </summary>
        /// <remarks>У клеток пара - фишка, у фишек - клетка</remarks>
        public BaseClickComponent Pair { get; set; }

        public void SetDefaultMaterial(Material material)
        {
            _defaultMaterial = material;
            SetMaterial(material);
        }
        public void SetMaterial(Material material = null)
        {
            //если переданный материал равен Null, то устанавливаем дефолтный материал
            //Debug.Log(_meshRenderer.sharedMaterial);
            _meshRenderer.sharedMaterial = material ? material : _defaultMaterial;
        }
        

        /// <summary>
        /// Событие клика на игровом объекте
        /// </summary>
        public event ClickEventHandler Clicked;

        /// <summary>
        /// Событие наведения и сброса наведения на объект
        /// </summary>
        public event FocusEventHandler Focused;


        //При навадении на объект мышки, вызывается данный метод
        //При наведении на фишку, должна подсвечиваться клетка под ней
        //При наведении на клетку - подсвечиваться сама клетка
        public abstract void OnPointerEnter(PointerEventData eventData);

        //Аналогично методу OnPointerEnter(), но срабатывает когда мышка перестает
        //указывать на объект, соответственно нужно снимать подсветку с клетки
        public abstract void OnPointerExit(PointerEventData eventData);

        //При нажатии мышкой по объекту, вызывается данный метод
        public void OnPointerClick(PointerEventData eventData)
		{
            Clicked?.Invoke(this);
        }

        //Этот метод можно вызвать в дочерних классах (если они есть) и тем самым пробросить вызов
        //события из дочернего класса в родительский
        protected void CallBackEvent(CellComponent target, bool isSelect)
        {
            Focused?.Invoke(target, isSelect);
		}


    }

    public enum ColorType
    {
        White,
        Black,
        noOne
    }
    public struct Coordinate
    {
        private int _x;
        private int _y;

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }

        public delegate void ClickEventHandler(BaseClickComponent component);
    public delegate void FocusEventHandler(CellComponent component, bool isSelect);
}