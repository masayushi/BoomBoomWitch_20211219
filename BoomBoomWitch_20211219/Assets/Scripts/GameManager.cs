using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �^�X���
    /// </summary>
    public Turn turn = Turn.My;

    [Header("�Ǫ��}�C")]
    public GameObject[] goEnemys;
    [Header("�u�]")]
    public GameObject goMarble;

    public enum Turn
    {
        My, Enemy
    }
}
