using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    public void UpdateUI(float moneyValue){
        moneyText.text = moneyValue.ToString();
        moneyText.rectTransform.DOPunchAnchorPos(Vector2.one * 3f, 1);
    }
    // IEnumerator RectPuncher(RectTransform _rect){
    //     _rect.DOPunchAnchorPos(Vector2.up, 0.2f,)
    //     yield return new WaitForSeconds(0.0f);
    // }
}
