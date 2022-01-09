using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 回合資料
    /// </summary>
    public Turn turn = Turn.My;

    [Header("怪物陣列")]
    public GameObject[] goEnemys;
    [Header("彈珠")]
    public GameObject goMarble;

    public enum Turn
    {
        My, Enemy
    }
}
