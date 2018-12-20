using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    #region Private 变量

    #endregion
    #region Protected 变量

    #endregion
    #region Public 变量

    #endregion

    #region Public 方法
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //从鼠标当前位置发射一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //声明保存射线检测结果的变量
            RaycastHit hit;
            //进行射线检测    ray哪一条射线    hit保存在哪里
            if (Physics.Raycast(ray, out hit))
            {
                //判断射线接碰撞
                if (hit.collider.gameObject.tag != "Plane")
                    return;
                //获取射线与地面的碰撞点
                Vector3 targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //Player向目标位置进行移动
                transform.DOMove(targetPos, 1f);
            }
        }
    }
    #endregion
    #region Private 方法

    #endregion
    #region Protected 方法

    #endregion

}