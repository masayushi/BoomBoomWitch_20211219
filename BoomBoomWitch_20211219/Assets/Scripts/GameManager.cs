using UnityEngine;
using System.Collections.Generic;

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
    [Header("�ѽL�s��")]
    public Transform traCheckboard;
    [Header("�ͦ��ƶq�̤p�P�̤j��")]
    public Vector2Int v2RandomEnemyCount = new Vector2Int(1, 10);

    // �Ҧ����ѽL��ƪ�����
    [SerializeField]
    private Transform[] traCheckboards;

    /// <summary>
    /// �ĤG�C�G�ͦ��Ǫ����ѽL
    /// </summary>
    [SerializeField]
    private Transform[] traColumnSecond;
    /// <summary>
    /// �ѽL���ƶq
    /// </summary>
    private int countRow = 9;

    /// <summary>
    /// �ĤG�C�����ޭȡG�B�z�Ǫ��ͦ�������
    /// </summary>
    [SerializeField]
    private List<int> indexColumSecond = new List<int>();



    private void Awake()
    {
        // �ѽL�}�C = �ѽL�s��.���o�l���󪺤���<�ܧΤ���>()
        traCheckboards = traCheckboard.GetComponentsInChildren<Transform>();
        // ��l�ĤG�C�ƶq
        traColumnSecond = new Transform[countRow];
        // ���o�ĤG�C���ѽL
        for (int i = 10; i < 10 + countRow; i++)
        {
            traColumnSecond[i - countRow - 1] = traCheckboards[i];
        }

        SpawnEnemy();
    }

    /// <summary>
    /// �ͦ��ĤH�G�H���ƶq v2RandomEnemyCount
    /// </summary>
    private void SpawnEnemy()
    {
        int countEnemy = Random.Range(v2RandomEnemyCount.x, v2RandomEnemyCount.y);

        indexColumSecond.Clear();                                                                   // �M���W���Ѿl�����

        for (int i = 0; i < 9; i++) indexColumSecond.Add(i);                                       // ��l�Ʀr 0 ~ 7

        for (int i = 0; i < countEnemy; i++)
        {
            int randomEnemy = Random.Range(0, goEnemys.Length);                                     // 0 ~ 2 - �H�� 0 �� 1 

            int randomColumSecond = Random.Range(0, indexColumSecond.Count);                        // �H���ĤG�C�����ޭȡG�Ĥ@��0 ~ 7 �A�ĤG����Ѿl���ƶq�H���� (�ت��O���F���n���Ǫ��b�P�@�Ӥ���W�ͦ�)

            Instantiate(goEnemys[randomEnemy], traColumnSecond[indexColumSecond[randomColumSecond]].position, Quaternion.Euler(0, 180, 0));

            indexColumSecond.RemoveAt(randomColumSecond);                                           // �R���w�g��m�Ǫ����ĤG�C�ѽL
        }
        int randomMarble = Random.Range(0, indexColumSecond.Count);                                 // �Ѿl���ѽL �k�o
        Instantiate(
            goMarble,
            traColumnSecond[indexColumSecond[randomMarble]].position + Vector3.up,
            Quaternion.identity);                                                                   // �ͦ��u�]�b�ѽL�W
    }

    /// <summary>
    /// �����^�X
    /// </summary>
    /// <param name="isMyTurn">�O�_�O���a�^�X</param>
    public void SwitchTurn(bool isMyTurn)
    {
        if (isMyTurn) turn = Turn.My;
        else turn = Turn.Enemy;
    }


    /// <summary>
    /// �^�X�G�ڤ�P�Ĥ�
    /// </summary>
    public enum Turn
    {
        My, Enemy
    }
}
