using UnityEngine;
using UnityEngine.Events;   // 事件
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 回合資料
    /// </summary>
    public Turn turn = Turn.My;


    [Header("敵方回合事件")]
    public UnityEvent onEnemyTurn;
    [Header("怪物陣列")]
    public GameObject[] goEnemys;
    [Header("彈珠")]
    public GameObject goMarble;
    [Header("棋盤群組")]
    public Transform traCheckboard;
    [Header("生成數量最小與最大值")]
    public Vector2Int v2RandomEnemyCount = new Vector2Int(1, 10);

    // 所有的棋盤格數的物件
    [SerializeField]
    private Transform[] traCheckboards;

    /// <summary>
    /// 第二列：生成怪物的棋盤
    /// </summary>
    [SerializeField]
    private Transform[] traColumnSecond;
    /// <summary>
    /// 棋盤欄位數量
    /// </summary>
    private int countRow = 9;

    /// <summary>
    /// 第二列的索引值：處理怪物生成不重複
    /// </summary>
    [SerializeField]
    private List<int> indexColumSecond = new List<int>();
    private ControlSystem controlSystem;


    private void Awake()
    {
        // 棋盤陣列 = 棋盤群組.取得子物件的元件<變形元件>()
        traCheckboards = traCheckboard.GetComponentsInChildren<Transform>();
        // 初始第二列數量
        traColumnSecond = new Transform[countRow];
        // 取得第二列的棋盤
        for (int i = 10; i < 10 + countRow; i++)
        {
            traColumnSecond[i - countRow - 1] = traCheckboards[i];
        }

        controlSystem = FindObjectOfType<ControlSystem>();

        SpawnEnemy();
    }

    /// <summary>
    /// 生成敵人：隨機數量 v2RandomEnemyCount
    /// </summary>
    private void SpawnEnemy()
    {
        int countEnemy = Random.Range(v2RandomEnemyCount.x, v2RandomEnemyCount.y);

        indexColumSecond.Clear();                                                                   // 清除上次剩餘的資料

        for (int i = 0; i < 9; i++) indexColumSecond.Add(i);                                       // 初始數字 0 ~ 7

        for (int i = 0; i < countEnemy; i++)
        {
            int randomEnemy = Random.Range(0, goEnemys.Length);                                     // 0 ~ 2 - 隨機 0 或 1 

            int randomColumSecond = Random.Range(0, indexColumSecond.Count);                        // 隨機第二列的索引值：第一次0 ~ 7 ，第二次抓剩餘的數量隨機值 (目的是為了不要讓怪物在同一個方塊上生成)

            Instantiate(goEnemys[randomEnemy], traColumnSecond[indexColumSecond[randomColumSecond]].position, Quaternion.Euler(0, 180, 0));

            indexColumSecond.RemoveAt(randomColumSecond);                                           // 刪除已經放置怪物的第二列棋盤
        }
        int randomMarble = Random.Range(0, indexColumSecond.Count);                                 // 剩餘的棋盤 女得
        Instantiate(
            goMarble,
            traColumnSecond[indexColumSecond[randomMarble]].position + Vector3.up,
            Quaternion.identity);                                                                   // 生成彈珠在棋盤上
    }

    private bool canSpawn = true;

    /// <summary>
    /// 切換回合
    /// </summary>
    /// <param name="isMyTurn">是否是玩家回合</param>
    public void SwitchTurn(bool isMyTurn)
    {
        if (isMyTurn)
        {
            turn = Turn.My;
            controlSystem.canShoot = true;
            RecycleMarble.recycleMarbles = 0;       // 回收的數量歸零
            if (canSpawn)                           // 如果 可以生成
            {
                canSpawn = false;                   // 不能生成
                Invoke("SpawnEnemy", 0.8f);         // 呼叫生成敵人
            }
        }
        else
        {
            canSpawn = true;
            turn = Turn.Enemy;
            onEnemyTurn.Invoke();
        }
    }


    /// <summary>
    /// 回合：我方與敵方
    /// </summary>
    public enum Turn
    {
        My, Enemy
    }
}
