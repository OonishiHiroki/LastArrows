using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    Plane plane = new Plane();

    //playerController player = new playerController();

    float distance = 0;

    [System.Obsolete]
    void Start()
    {
        //LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        //線の幅
        //renderer.SetWidth(0.1f, 0.1f);
        //頂点の数
        //renderer.SetVertexCount(2);
        //頂点の設定
        //renderer.SetPosition(0, player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            //カメラとマウスの位置を元にRayを準備
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
            plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
            if (plane.Raycast(ray, out distance))
            {
                //距離を元に交点を算出して、交点の方を向く
                var lookPoint = ray.GetPoint(distance);
                transform.LookAt(lookPoint);
            }
        }
    }
}
