using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// 磨床移动类
/// </summary>
public class GrinderMove : MonoBehaviour
{
    #region Private 变量

    #endregion
    #region Protected 变量

    #endregion
    #region Public 变量
    public GameObject grindingWheel;//砂轮
    public GameObject grindingShelf;// 砂轮架
    public GameObject workSpace;//工作台
    public Transform grindingLeftMax;//左移最大限度
    public Transform grindingShelfDownMax;
    public Transform grindingShelfUpMax;
    public Transform workSpaceLeftMax;
    public Transform workSpaceRightMax;
    public Canvas canvas;
    private static GrinderMove instance;
    public static GrinderMove Instance
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
    Vector3 vector = new Vector3(0.02f,0,0);    //砂轮每次移动的距离
    Vector3 vector1 = new Vector3(0,0.02f,0);
    Vector3 vector2 = new Vector3(0.02f,0,0);
    #endregion

    #region Public 方法
    //砂轮匀速转动
    public void GrindingWheelRotate()
    {
        grindingWheel.transform.Rotate(transform.forward * 60f * Time.deltaTime);
    }
    //砂轮左移
    public void LeftGrinding()
    {//左移限度
        if (grindingWheel.transform.position.x< grindingLeftMax.position.x)
        {
              grindingWheel.transform.Translate(vector,0);
        }
        else
        {
            grindingWheel.transform.Translate(Vector3.zero, 0);
        }
       
    }
    //砂轮架上移
    public void GrindingShelfUp()
    {
        if (grindingShelf.transform.position.y< grindingShelfUpMax.position.y)
        {
          grindingShelf.transform.Translate(vector1,0);
        }
        else
        {
            grindingShelf.transform.Translate(Vector3.zero, 0);
        }
    }
    //砂轮架下移
    public void GrindingShelfDown()
    {
        if (grindingShelf.transform.position.y > grindingShelfDownMax.position.y)
        {
            grindingShelf.transform.Translate(-vector1, 0);
        }
        else
        {
            grindingShelf.transform.Translate(Vector3.zero, 0);
        }
    }
    //工作空间移到最左侧
    public void WorkSpaceLeftMax()
    {
        workSpace.transform.DOMoveX(workSpaceLeftMax.position.x,1f);
    }
    //工作台左移
    public void WorkSpaceLeft()
    {
        if (workSpace.transform.position.x< workSpaceLeftMax.position.x)
        {
         workSpace.transform.Translate(vector2,0);
        }
        else
        {
            workSpace.transform.Translate(Vector3.zero, 0);
        }
    }
public   void WorkSpaceRight()
    {
        if (workSpace.transform.position.x > workSpaceRightMax.position.x)
        {
            workSpace.transform.Translate(-vector2, 0);
        }
        else
        {
            workSpace.transform.Translate(Vector3.zero, 0);
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
        GrindingWheelRotate();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
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