using UnityEngine;

public class EnemyPropControl : MonoBehaviour
{
    public GameManager gm;
    [Header("每次移動的距離")]
    public float moveDistance = 2; // 要看自己角色移動的方向做決定

    [Header("移動的座標底線")]
    public float moveUnderLine = -2; // 要看自己物件的位置做決定

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        transform.position += Vector3.forward * moveDistance;

        if (transform.position.z <= moveUnderLine) DestroyObject();
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
