using UnityEngine;

namespace Ziggurat
{
    public class ZigguratCard : MonoBehaviour
    {
        [SerializeField]private WarriorColor _color;
        public WarriorColor GetColor()
        {
            return _color;
        }
    }
}

