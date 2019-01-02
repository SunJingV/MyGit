using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 镗床移动
/// </summary>
public class DrillMove : MonoBehaviour
{
    #region Private 变量

    #endregion
    #region Protected 变量

    #endregion
    #region Public 变量
    public GameObject drill;//钻头
    public GameObject drillAll;//钻头整体
    public Transform drillAllUpMax;//钻头整体上移极限
    public Transform drillAllDownMax;//钻头整体下移极限
    public Transform drillExtendMax;//钻头伸出最大极限
    public Transform drillRetactionMax;//钻头缩入最大极限
    public Canvas canvas;//画布
    public GameObject moveWorkSpace;//要进行移动的工作台部分
    public GameObject workSpaceForwardBack;//工作台前后移动部分
    public GameObject workSpaceLeftRightParent;//工作台左右移动部分父对象
    public GameObject workSpaceLeftRight;//工作台左右移动部分
    public Transform moveWorkSpaceLeftMax;//工作台左移最大限度
    public Transform moveWorkSpaceRightMax;
    public Transform moveWorkSpaceForwardMax;//工作台前移最大限度
    public Transform moveWorkSpaceBackMax;
    Vector3 vector = new Vector3(0.02f,0,0);//钻头移动，工作台前后移动
    Vector3 vector1 = new Vector3(0,0.02f,0);//钻头整体每秒移动单位
    Vector3 vector2 = new Vector3(0,0,0.02f);//工作台整体前后移动的单位
    [HideInInspector]
    public float drillAngle = 0f;//钻头转动的角度
    [HideInInspector]
    public bool isRotate = false;
    private static DrillMove instance;
    public static DrillMove Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    #endregion

    #region Public 方法
    //钻头伸出
 public void DrillExrend()
    {
        if (drill.transform.position.x<drillExtendMax.position.x)
        {
            drill.transform.Translate(vector,0);
        }
        else
        {
            drill.transform.Translate(Vector3.zero, 0);
        }
    }
    //钻头缩入
    public void DrillRetraction()
    {
        if (drill.transform.position.x>drillRetactionMax.position.x)
        {
            drill.transform.Translate(-vector, 0);
        }
        else
        {
            drill.transform.Translate(Vector3.zero, 0);
        }
    }
    //钻头整体上移
    public void DrillAllUp()
    {
        if (drillAll.transform.position.y<drillAllUpMax.position.y)
        {
            drillAll.transform.Translate(vector1,0);
        }
        else
        {
            drillAll.transform.Translate(Vector3.zero, 0);
        }
    }
    //钻头整体下移
    public void DrillAllDown()
    {
        if (drillAll.transform.position.y > drillAllDownMax.position.y)
        {
            drillAll.transform.Translate(-vector1, 0);
        }
        else
        {
            drillAll.transform.Translate(Vector3.zero, 0);
        }
    }
    //工作台整体前移
    public void MoveWorkSpaceForward()
    {
        workSpaceLeftRight.transform.SetParent(workSpaceLeftRightParent.transform);
        if (moveWorkSpace.transform.position.z<moveWorkSpaceForwardMax.position.z)
        {
           moveWorkSpace.transform.Translate(vector2,0);
        }
        else
        {
            moveWorkSpace.transform.Translate(Vector3.zero, 0);
        }
    }
    //工作台整体后移
    public void MoveWorkSpaceBack()
    {//工作台底下左右移动部件不参与工作台的前后移动
        workSpaceLeftRight.transform.SetParent(workSpaceLeftRightParent.transform);
        if (moveWorkSpace.transform.position.z > moveWorkSpaceBackMax.position.z)
        {
            moveWorkSpace.transform.Translate(-vector2, 0);
        }
        else
        {
            moveWorkSpace.transform.Translate(Vector3.zero, 0);
        }
    }
    //工作台整体左移
    public void MoveWorkSpaceLeft()
    {
      workSpaceLeftRight.transform.SetParent(moveWorkSpace.transform) ;//设置左右移动父对象
        if (moveWorkSpace.transform.position.x<moveWorkSpaceLeftMax.position.x)
        {
        moveWorkSpace.transform.Translate(vector,0);
        }
        else
        {
            moveWorkSpace.transform.Translate(Vector3.zero, 0);
        }
    }
    public void MoveWorkSpaceRight()
    {
        workSpaceLeftRight.transform.SetParent(moveWorkSpace.transform);//设置左右移动父对象
        if (moveWorkSpace.transform.position.x >moveWorkSpaceRightMax.position.x)
        {
            moveWorkSpace.transform.Translate(-vector, 0);
        }
        else
        {
            moveWorkSpace.transform.Translate(Vector3.zero, 0);
        }
    }
    #endregion
    #region Private 方法
    private void Awake()
    {
        instance = this;
        canvas.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isRotate)
        {
            //旋转
         DrillRotate();
        }     
    }
    //钻头转动
    private void DrillRotate()
    {
        drill.transform.Rotate(Vector3.forward, drillAngle * Time.deltaTime);
    }
    //碰撞检测
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(false);
        }
    }
        #endregion
        #region Protected 方法

        #endregion
  
    }