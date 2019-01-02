using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrillBtn : ButtonType
{
    #region Private 变量

    #endregion
    #region Protected 变量

    #endregion
    #region Public 变量
    public DrillBtnType drillBtnType=DrillBtnType.None;
 //  public bool isRotateTrue=false;
    #endregion

    #region Public 方法
    public override void SwitchBtn()
    {
      //  DrillMove.Instance.isRotate = false;
        switch (drillBtnType)
        {
            case DrillBtnType.None:
                break;
            case DrillBtnType.drillExtend://钻头伸出
                DrillMove.Instance.DrillExrend();
                break;
            case DrillBtnType.drillRetraction://钻头缩入
                DrillMove.Instance.DrillRetraction();
                break;
            case DrillBtnType.drillHighPositiveRotate://钻头高速正旋转
                DrillMove.Instance.drillAngle = 400f;
                 DrillMove.Instance.isRotate = !DrillMove.Instance.isRotate;
                break;
            case DrillBtnType.drillHighNegativeRotate://钻头高速负旋转
                DrillMove.Instance.drillAngle = -400f;
                DrillMove.Instance.isRotate = !DrillMove.Instance.isRotate;
                break;
            case DrillBtnType.drillLowPositiveRotate://钻头低速正旋转
                DrillMove.Instance.drillAngle = 100f;
               DrillMove.Instance.isRotate = !DrillMove.Instance.isRotate;
                break;
            case DrillBtnType.drillLowNegativeRotate:
                DrillMove.Instance.drillAngle = -100f;
                DrillMove.Instance.isRotate = !DrillMove.Instance.isRotate;
                break;
            case DrillBtnType.drillAllUp:
                DrillMove.Instance.DrillAllUp();
                break;
            case DrillBtnType.drillAllDown:
                DrillMove.Instance.DrillAllDown();
                break;
            case DrillBtnType.workSpaceForward://工作台前移
                DrillMove.Instance.MoveWorkSpaceForward();
                break;
            case DrillBtnType.workSpaceBack:
                DrillMove.Instance.MoveWorkSpaceBack();
                break;
            case DrillBtnType.workSpaceLeft:
                DrillMove.Instance.MoveWorkSpaceLeft();
                break;
            case DrillBtnType.workSpaceRight:
                DrillMove.Instance.MoveWorkSpaceRight();
                break;
            default:
                break;
        }      
    }
    #endregion
    #region Private 方法

    #endregion
    #region Protected 方法

    #endregion

}
public enum DrillBtnType
{
    None,
    drillExtend,//钻头伸出
    drillRetraction,//钻头缩入
    drillHighPositiveRotate,//钻头高速正转
    drillHighNegativeRotate,//钻头高速负转
    drillLowPositiveRotate,//钻头低速正转
    drillLowNegativeRotate,//钻头低速负转
    drillAllUp,//钻头整体上移
    drillAllDown,//钻头整体下移
    workSpaceForward,//工作台前移
    workSpaceBack,//
    workSpaceLeft,//
    workSpaceRight,//
}