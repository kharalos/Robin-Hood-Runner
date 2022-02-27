using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText, scoreText;
    [SerializeField] private Image swipeSymbol;
    [SerializeField] private GameObject startPanel, endPanel;
    IEnumerator Start(){
        yield return new WaitForSeconds(0.5f);

        Sequence s = DOTween.Sequence();

		s.Append(swipeSymbol.rectTransform.DOAnchorPosX(Screen.width/8, 2f,false).SetRelative().SetEase(Ease.InOutQuad));
		s.SetLoops(-1, LoopType.Yoyo);
    }
    public void HideStartHUD(){
        //s.Kill();
        startPanel.SetActive(false);
    }
    public void UpdateUI(float moneyValue){
        moneyText.text = moneyValue.ToString();
        moneyText.rectTransform.DOShakeAnchorPos(0.2f, 10f);
    }

    public void EndMenu(float money){
        endPanel.SetActive(true);
        scoreText.text = money.ToString();
    }

}
