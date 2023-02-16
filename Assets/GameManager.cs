using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cube1, cube2, button1, button2;
    [SerializeField] private float time1, time2;
    [SerializeField] private Vector3 posB;
    public void Click()
    {
        button1.GetComponent<Button>().interactable = false;

        var sequence = DOTween.Sequence();

        sequence.Append(cube1.transform.DOMove(posB + Vector3.one, time1));
        sequence.Append(cube1.transform.DOMove(posB, time1));
        sequence.Append(cube2.transform.DOScale(cube2.transform.localScale * 2, time2));
        sequence.Append(cube2.transform.DOScale(cube2.transform.localScale / 2, time2));
        sequence.Append(button1.GetComponent<CanvasGroup>().DOFade(0, time1));
        sequence.Join(button2.GetComponent<CanvasGroup>().DOFade(0, time1)).OnComplete(() => {
            button2.GetComponent<Button>().interactable = false;
        });
    }

}
