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
    public float playerSpeed=0f;//人物速度
    Vector3 move;//移动的距离
    Vector3 groundNormal;//地面法线
    float turnAmount;//人物旋转角度
    //声明保存射线检测结果的变量
    RaycastHit hit;
    #endregion
    #region Public 方法
    public void Start()
    {
        playerAnimator.SetFloat("speed", playerSpeed);
    }
    public void Update()
    {
        playerSpeed = 2f;
        //跟随鼠标移动
        if (Input.GetMouseButtonDown(0))
        {
            //从鼠标当前位置发射一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);         
            //进行射线检测    ray哪一条射线    hit保存在哪里
            if (Physics.Raycast(ray, out hit))
            {
                //判断射线接碰撞
                if (hit.collider.gameObject.tag == "Plane")
                {
                    move = hit.point - transform.position;//人物距离目标点的距离
                }
                else
                {
                    move = Vector3.zero;
                }
            }
        }
                //距离目标点的距离，每帧都在变化
                if (Vector3.Distance(hit.point, transform.position) > 0.5f && move != Vector3.zero)
                {
                    Move(move);
                }
        else
        {
            StopMove();
        }
        #region//Dotween移动
        //获取射线与地面的碰撞点
        //   Vector3 targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        //distance= Vector3.Distance(hit.point, transform.position);
        //    playerAnimator.SetFloat("speed", playerSpeed);
        //  transform.DOLookAt(hit.point, 0.5f).OnComplete(() => {
        //     transform.DOMove(hit.point, (distance / playerSpeed)).OnComplete(StopMove);
        //  });//朝向
        //Player向目标位置进行移动              
        //  targetPos.Normalize();//向量归一化，只在意方向，不在意大小
        //  Vector3.ProjectOnPlane();
        //   transform.InverseTransformDirection();//将世界坐标系中的向量转化成本地坐标系中的向量
        #endregion
    }
    //移动完成以后恢复静立
    public void StopMove()
    {
        playerSpeed = 0f;
        playerAnimator.SetFloat("speed", playerSpeed);
    }

    #endregion
    #region Private 方法
    //人物移动
    private void Move(Vector3 move)
    {
        playerSpeed = 2f;
       playerAnimator.SetFloat("speed", playerSpeed);
        if (move.magnitude>1f)//如果向量的模大于1
        {
            move.Normalize();//向量归一化、
        }
        //将世界坐标的move转化成本地坐标的move
        move = transform.InverseTransformDirection(move);
        RaycastHit hitInfo;
        if (Physics.Raycast(
            transform.position + Vector3.up * 0.1f,
            Vector3.down, out hitInfo, 0.1f))
        //将本地的坐标系向上移动0.1f,发射射线向下，射线长度是0.1f
        //判断人物是否站在地面上
        {
            groundNormal = hitInfo.normal;//存储地面法向量
        }
        else
        {
            groundNormal = Vector3.up;
        }
        //投影一个向量到平面正交法向量定义的平面上。
        move = Vector3.ProjectOnPlane(move, groundNormal);
        turnAmount = Mathf.Atan2(move.x, move.z);//反三角函数，求出人物旋转角度
        //forwardAmount = move.z;
        transform.Rotate(0f, turnAmount * 240f * Time.deltaTime, 0f);
        transform.Translate(move * playerSpeed * Time.deltaTime);
    }
    #endregion
    #region Protected 方法

    #endregion

}