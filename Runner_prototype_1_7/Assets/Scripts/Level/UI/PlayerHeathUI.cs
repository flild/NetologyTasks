using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHeathUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _healthText;

    public void ShowHeath(float value)
    {
        _healthText.text = value.ToString() + " heart";
    }
}
