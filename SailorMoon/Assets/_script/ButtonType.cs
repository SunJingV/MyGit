using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonType : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    #region Private 变量
    // 延迟时间
    protected float delay = 0.05f;
    // 按钮是否是按下状态
    protected bool isDown = false;
    // 按钮最后一次是被按住状态时候的时间
    protected float lastIsDownTime;
    #endregion
    #region Protected 变量

    #endregion
    #region Public 变量
    public ButtonDownType buttonType=ButtonDownType.None;//按钮对应的类型   
    #endregion

    #region Public 方法
    //根据类型调用不同的方法
 public virtual void SwitchBtn()
    {
        switch (buttonType)
        {
            case ButtonDownType.None:
                break;
            case ButtonDownType.girindingLeft:
                GrinderMove.Instance.LeftGrinding();
                break;
            case ButtonDownType.grindingShelfUp:
                GrinderMove.Instance.GrindingShelfUp();
                break;
            case ButtonDownType.grindingShelfDown:
                GrinderMove.Instance.GrindingShelfDown();
                break;
            case ButtonDownType.workSpaceLeft:
                GrinderMove.Instance.WorkSpaceLeft();
                break;
            case ButtonDownType.workSpaceLeftMax:
                GrinderMove.Instance.WorkSpaceLeftMax();
                break;
            case ButtonDownType.workSpaceRight:
                GrinderMove.Instance.WorkSpaceRight();
                break;
            default:
                break;
        }
    }
public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        lastIsDownTime = Time.time;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }
    #endregion
    #region Private 方法
    protected void Update()
    {
        if (isDown)
        {
            // 当前时间 -  按钮最后一次被按下的时间 > 延迟时间0.2秒
            if (Time.time - lastIsDownTime > delay)
            {
                // 触发长按方法
                SwitchBtn();                
                // 记录按钮最后一次被按下的时间
                lastIsDownTime = Time.time;
            }
        }
    }
}
    #endregion
    #region Protected 方法

    #endregion
public  enum ButtonDownType
{
    None=0,
    girindingLeft,//砂轮左移
 grindingShelfUp,//砂轮架上移按钮
 grindingShelfDown,//砂轮架下移按钮
 workSpaceLeft,//工作台左移按钮
 workSpaceLeftMax,//工作台左移按钮
 workSpaceRight//工作台左移按钮
}