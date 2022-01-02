using UnityEngine;

/// <summary>
/// 控制系統
/// 指向滑鼠位置
/// 發射彈珠
/// 回合控制
/// </summary>
public class ControlSystem : MonoBehaviour
{
    #region 欄位
    [Header("箭頭")]
    public GameObject goArrow;
    [Header("生成彈珠位置")]
    public Transform traSpawnPoint;
    [Header("彈珠預置物")]
    public GameObject goMarbles;
    [Header("發射速度"), Range(0, 5000)]
    public float speedShoot = 750;
    #endregion

    #region 事件

    #endregion

    #region 方法

    #endregion

}
