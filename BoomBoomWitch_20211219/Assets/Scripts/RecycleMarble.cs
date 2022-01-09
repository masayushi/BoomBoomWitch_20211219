using UnityEngine;

/// <summary>
/// 回收彈珠系統
/// </summary>
public class RecycleMarble : MonoBehaviour
{
    /// <summary>
    /// 回收的彈珠數量
    /// </summary>
    public static int recycleMarbles;

    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("彈珠"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = new Vector3(0, 0, 100);

            // 回收彈珠數量 增加
            recycleMarbles++;
            if (recycleMarbles == ControlSystem.allMarbles) gm.SwitchTurn(false);
        }
    }
}
