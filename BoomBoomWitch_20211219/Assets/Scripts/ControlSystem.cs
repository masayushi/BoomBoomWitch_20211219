using UnityEngine;
using System.Collections.Generic; // まノ╰参.栋. (List)
using System.Collections;         // まノ╰参.栋

/// <summary>
/// 北╰参
/// 菲公竚
/// 祇甮紆痌
/// 北
/// </summary>
public class ControlSystem : MonoBehaviour
{
    #region 逆
    [Header("絙繷")]
    public GameObject goArrow;
    [Header("ネΘ紆痌竚")]
    public Transform traSpawnPoint;
    [Header("紆痌箇竚")]
    public GameObject goMarbles;
    [Header("祇甮硉"), Range(0, 5000)]
    public float speedShoot = 3500;
    [Header("甮絬璶窱疾瓜糷")]
    public LayerMask layerToHit;
    [Header("代刚菲公竚")]
    public Transform traTestMousePosition;
    [Header("┮Τ紆痌")]
    public List<GameObject> listMarbles = new List<GameObject>();
    [Header("祇甮丁筳")]
    public float fireInterval = 0.1f;

    /// <summary>
    /// ┮Τ紆痌计秖
    /// </summary>
    public static int allMarbles;

    /// <summary>
    /// 祇甮程计秖
    /// </summary>
    public static int maxMarbles = 2;

    /// <summary>
    /// –Ω甮紆痌计秖
    /// </summary>
    public static int shootMarbles;

    /// <summary>
    /// 琌祇甮
    /// </summary>
    public bool canShoot = true;
    #endregion

    #region ㄆン

    private void Start()
    {

        for (int i = 0; i < 10; i++) SpawnMarble();
    }

    private void Update()
    {
        MouseControl();
    }
    #endregion

    #region よ猭

    /// <summary>
    /// ネΘ紆痌睲虫ず
    /// </summary>
    private void SpawnMarble()
    {
        // 紆痌羆计糤
        allMarbles++;
        // ┮Τ紆痌睲虫.睰(ネΘ紆痌)
        listMarbles.Add(Instantiate(goMarbles, new Vector3(0, 0, 100), Quaternion.identity));
    }

    /// <summary>
    /// 菲公北
    /// </summary>
    private void MouseControl()
    {
        if (!canShoot) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            goArrow.SetActive(true);
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 v3Mouse = Input.mousePosition;

            // print("菲公畒夹" + v3Mouse);

            // 甮絬 = 璶尼紇诀.棵辊畒夹锣甮絬(菲公畒夹)
            Ray rayMouse = Camera.main.ScreenPointToRay(v3Mouse);

            // 甮絬窱疾戈癟
            RaycastHit hit;

            // 狦 甮絬ゴン碞暗矪瞶
            // 瞶 甮絬窱疾 (甮絬, 甮絬窱疾戈癟, 禯瞒, 瓜糷)
            if (Physics.Raycast(rayMouse, out hit, 100, layerToHit))
            {
                print("菲公甮絬ゴン" + hit.collider.name);

                Vector3 hitPosition = hit.point;                    // 眔窱疾戈癟畒夹
                hitPosition.y = 0.5f;                               // 秸俱蔼禸
                traTestMousePosition.position = hitPosition;        // 穝代刚ン畒夹

                // 竲︹ z禸 - 代刚ン畒夹 - à︹畒夹 (秖)
                transform.forward = traTestMousePosition.position - transform.position; // forward = z 禸
            }
        }

        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            canShoot = false;
            StartCoroutine(FireMarble());
        }
    }

    private IEnumerator FireMarble()
    {

        shootMarbles = 0;

        for (int i = 0; i < maxMarbles; i++)
        {
            shootMarbles++;
            GameObject temp = listMarbles[i];
            temp.transform.position = traSpawnPoint.position;
            temp.transform.rotation = traSpawnPoint.rotation;
            temp.GetComponent<Rigidbody>().velocity = Vector3.zero;                         // 硉耴箂
            temp.GetComponent<Rigidbody>().AddForce(traSpawnPoint.forward * speedShoot);    // 祇甮 紆痌
            yield return new WaitForSeconds(fireInterval);                                  // 丁筳
        }
        goArrow.SetActive(false);
    }
    #endregion

}
