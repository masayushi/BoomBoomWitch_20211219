using UnityEngine;
using System.Collections.Generic; // 引用系統.集合.一般 (包含List)

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
    public float speedShoot = 4500;
    [Header("射線要碰撞的圖層")]
    public LayerMask layerToHit;
    [Header("測試滑鼠位置")]
    public Transform traTestMousePosition;
    [Header("所有彈珠")]
    public List<GameObject> listMarbles = new List<GameObject>();
    #endregion

    #region 事件

    private void Start()
    {
        for (int i = 0; i < 2; i++) SpawnMarble();
    }

    private void Update()
    {
        MouseControl();
    }
    #endregion

    #region 方法

    private void SpawnMarble()
    {
        // 所有彈珠清單.添加(生成彈珠)
        listMarbles.Add(Instantiate(goMarbles));
    }

    /// <summary>
    /// 滑鼠控制
    /// </summary>
    private void MouseControl()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            goArrow.SetActive(true);
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 v3Mouse = Input.mousePosition;

            // print("滑鼠座標" + v3Mouse);

            // 射線 = 主要攝影機.螢幕座標轉射線(滑鼠座標)
            Ray rayMouse = Camera.main.ScreenPointToRay(v3Mouse);

            // 射線碰撞資訊
            RaycastHit hit;

            // 如果 射線打到物件就做處理
            // 物理 射線碰撞 (射線, 射線碰撞資訊, 距離, 圖層)
            if (Physics.Raycast(rayMouse, out hit, 100, layerToHit))
            {
                print("滑鼠射線打到物件" + hit.collider.name);

                Vector3 hitPosition = hit.point;                    // 取得碰撞資訊的座標
                hitPosition.y = 0.5f;                               // 調整高度軸向
                traTestMousePosition.position = hitPosition;        // 更新測試物件座標

                // 腳色的 z軸 - 測試物件的座標 - 角色的座標 (向量)
                transform.forward = traTestMousePosition.position - transform.position; // forward = z 軸
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GameObject temp = Instantiate(goMarbles, traSpawnPoint.position, traSpawnPoint.rotation);
            temp.GetComponent<Rigidbody>().AddForce(traSpawnPoint.forward * speedShoot);
            goArrow.SetActive(false);
        }
    }
    #endregion

}
