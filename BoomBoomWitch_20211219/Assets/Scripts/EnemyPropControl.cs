using UnityEngine;
using UnityEngine.UI;

public class EnemyPropControl : MonoBehaviour
{
    public GameManager gm;
    [Header("每次移動的距離")]
    public float moveDistance = 2; // 要看自己角色移動的方向做決定

    [Header("移動的座標底線")]
    public float moveUnderLine = -2; // 要看自己物件的位置做決定
    [Header("彈珠的名稱")]
    public string nameMarble;
    [Header("血量")]
    public float hp = 100;
    [Header("是否有介面")]
    public bool hasUI;

    private float hpMax;
    private Image imgHp;
    private Text textHp;

    private void Awake()
    {
        hpMax = hp;

        if (hasUI)
        {
        imgHp = transform.Find("畫布血條").Find("血量").GetComponent<Image>();
        textHp = transform.Find("畫布血條").Find("血量").GetComponent<Text>();
        textHp.text = hp.ToString();
        }
        gm = FindObjectOfType<GameManager>();        // 透過類型尋找物件 - 只適用於此場景只有一個類型時
        gm.onEnemyTurn.AddListener(Move);
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        transform.position -= Vector3.forward * moveDistance;

        gm.SwitchTurn(true);

        if (transform.position.z <= moveUnderLine) DestroyObject();
    }

    /// <summary>
    /// 刪除物件
    /// </summary>
    private void DestroyObject()
    {
        Destroy(gameObject);

        if (gameObject.name.Contains("彈珠"))
        {
            ControlSystem.maxMarbles++;
        }
    }

    private void Hurt(float damage)
    {
        hp -= damage;
        if (hasUI)
        {
        imgHp.fillAmount = hp / hpMax;
        textHp.text = hp.ToString();
        }
        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains(nameMarble))
        {
            Hurt(collision.gameObject.GetComponent<Marbles>().attack);
        }
    }
}
