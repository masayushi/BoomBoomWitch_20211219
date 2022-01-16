using JetBrains.Annotations;
using UnityEngine;


/// <summary>
/// 彈珠系統
/// </summary>
public class Marbles : MonoBehaviour
{
    /// <summary>
    /// 攻擊力
    /// </summary>
    public float attack;
    
    private void Awake()
    {
        // 物理 API 內的 忽略圖層間的碰撞(A圖層,B圖層) 忽略 A B圖層的碰撞
        Physics.IgnoreLayerCollision(6, 6);
    }
}
