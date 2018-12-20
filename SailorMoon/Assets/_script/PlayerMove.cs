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
    public Animator playerAnimator;//角色移动状态机
    public float playerSpeed;//人物速度
    float distance;//距离
    #endregion

    #region Public 方法
    public void Update()
    {
        playerSpeed = 2f;
        //跟随鼠标移动
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
                distance = Vector3.Distance(transform.position,targetPos);//距离目标点的距离
                transform.DOLookAt(hit.point,1f);//朝向
                //Player向目标位置进行移动
                playerAnimator.SetFloat("speed",playerSpeed);
                transform.DOMove(targetPos, (distance/playerSpeed)).OnComplete(StopMove);              
            }
        }
    }
    public void StopMove()
    {
        playerSpeed = 0f;
        playerAnimator.SetFloat("speed", playerSpeed);
    }
    #endregion
    #region Private 方法

    #endregion
    #region Protected 方法

    #endregion

}