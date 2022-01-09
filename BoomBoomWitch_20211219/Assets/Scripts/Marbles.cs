using UnityEngine;

public class Marbles : MonoBehaviour
{
    private void Awake()
    {
        // 物理 API 內的 忽略圖層間的碰撞(A圖層,B圖層) 忽略 A B圖層的碰撞
        Physics.IgnoreLayerCollision(6, 6);
    }
}
