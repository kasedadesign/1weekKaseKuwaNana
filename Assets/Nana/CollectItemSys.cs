using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItemSys : MonoBehaviour
{
    [SerializeField]
    private GameObject SelectedItem;

    public void OnClickItem()
    {
        //TODO:左の枠から順にオンにする
        SelectedItem.SetActive(true);

        //TODO:クリックされたゲームオブジェクト取得。falseにする。
        gameObject.SetActive(false);
    }
}
