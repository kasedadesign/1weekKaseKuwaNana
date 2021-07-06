using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UseItemSys : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPushed = false; // マウスが押されているか押されていないか
    private Vector3 _nowMousePosi; // 現在のマウスのワールド座標

    // Update is called once per frame
    void Update()
    {
        Vector3 nowmouseposi;
        Vector3 diffposi;

        // マウスが押下されている時、オブジェクトを動かす
        if (_isPushed) {
            // 現在のマウスのワールド座標を取得
            nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 一つ前のマウス座標との差分を計算して変化量を取得
            diffposi = nowmouseposi - _nowMousePosi;

            //　Y成分のみ変化させる
            //diffposi.x = 0;
            diffposi.z = 0;

            // 開始時のオブジェクトの座標にマウスの変化量を足して新しい座標を設定
            GetComponent<Transform>().position += diffposi;
            // 現在のマウスのワールド座標を更新
            _nowMousePosi = nowmouseposi;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 押下開始　フラグを立てる
        _isPushed = true;
        // マウスのワールド座標を保存
        _nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 押下終了　フラグを落とす
        _isPushed = false;
        _nowMousePosi = Vector3.zero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked!");
    }
}
