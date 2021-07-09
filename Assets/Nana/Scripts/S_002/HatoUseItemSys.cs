using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class HatoUseItemSys : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    ///鳩。時間不足につきよくないコードですみません
    /// </summary>
    private bool _isPushed = false; // マウスが押されているか押されていないか
    private Vector3 _nowMousePosi; // 現在のマウスのワールド座標

    private Vector2 prevPosition;

    //タイムライン
    [SerializeField] PlayableDirector director1;
    [SerializeField] PlayableDirector director2;
    [SerializeField] PlayableDirector director3;

    //ターゲット
    [SerializeField] GameObject targetObj1;
    [SerializeField] GameObject targetObj2;
    [SerializeField] GameObject targetObj3;

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
            diffposi.z = 0;

            // 開始時のオブジェクトの座標にマウスの変化量を足して新しい座標を設定
            GetComponent<Transform>().position += diffposi;

            // 現在のマウスのワールド座標を更新
            _nowMousePosi = nowmouseposi;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPushed = true;

        // マウスのワールド座標を保存
        _nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //追加
        prevPosition = transform.position;

        //Debug.Log("down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPushed = false;
        _nowMousePosi = Vector3.zero;

        bool flg = true;
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            if (hit.gameObject == targetObj1.gameObject)
            {
                if (OffTimeLine.notPlayTimeLine)
                {
                    transform.position = prevPosition;
                    return;
                }

                transform.position = hit.gameObject.transform.position;
                flg = false;

                PlayTimeline(hit.gameObject);

                gameObject.SetActive(false);
            }else if (hit.gameObject == targetObj2.gameObject)
            {
                if (OffTimeLine.notPlayTimeLine)
                {
                    transform.position = prevPosition;
                    return;
                }

                transform.position = hit.gameObject.transform.position;
                flg = false;

                PlayTimeline(hit.gameObject);

                gameObject.SetActive(false);
            }else if (hit.gameObject == targetObj3.gameObject)
            {
                if (OffTimeLine.notPlayTimeLine)
                {
                    transform.position = prevPosition;
                    return;
                }

                transform.position = hit.gameObject.transform.position;
                flg = false;

                PlayTimeline(hit.gameObject);

                gameObject.SetActive(false);
            }
        }

        if (flg)
        {
            transform.position = prevPosition;
        }
    }

    private void PlayTimeline(GameObject target)
    {
        if (target == targetObj1)
        {
            director1.Play();
        }else if (target == targetObj2)
        {
            director2.Play();
        }else if (target == targetObj3)
        {
            director3.Play();
        }
    }
}
