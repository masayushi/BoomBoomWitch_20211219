using UnityEngine;
using System.Collections.Generic; // �ޥΨt��.���X.�@�� (�]�tList)

/// <summary>
/// ����t��
/// ���V�ƹ���m
/// �o�g�u�]
/// �^�X����
/// </summary>
public class ControlSystem : MonoBehaviour
{
    #region ���
    [Header("�b�Y")]
    public GameObject goArrow;
    [Header("�ͦ��u�]��m")]
    public Transform traSpawnPoint;
    [Header("�u�]�w�m��")]
    public GameObject goMarbles;
    [Header("�o�g�t��"), Range(0, 5000)]
    public float speedShoot = 4500;
    [Header("�g�u�n�I�����ϼh")]
    public LayerMask layerToHit;
    [Header("���շƹ���m")]
    public Transform traTestMousePosition;
    [Header("�Ҧ��u�]")]
    public List<GameObject> listMarbles = new List<GameObject>();
    #endregion

    #region �ƥ�

    private void Start()
    {
        for (int i = 0; i < 2; i++) SpawnMarble();
    }

    private void Update()
    {
        MouseControl();
    }
    #endregion

    #region ��k

    private void SpawnMarble()
    {
        // �Ҧ��u�]�M��.�K�[(�ͦ��u�])
        listMarbles.Add(Instantiate(goMarbles));
    }

    /// <summary>
    /// �ƹ�����
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

            // print("�ƹ��y��" + v3Mouse);

            // �g�u = �D�n��v��.�ù��y����g�u(�ƹ��y��)
            Ray rayMouse = Camera.main.ScreenPointToRay(v3Mouse);

            // �g�u�I����T
            RaycastHit hit;

            // �p�G �g�u���쪫��N���B�z
            // ���z �g�u�I�� (�g�u, �g�u�I����T, �Z��, �ϼh)
            if (Physics.Raycast(rayMouse, out hit, 100, layerToHit))
            {
                print("�ƹ��g�u���쪫��" + hit.collider.name);

                Vector3 hitPosition = hit.point;                    // ���o�I����T���y��
                hitPosition.y = 0.5f;                               // �վ㰪�׶b�V
                traTestMousePosition.position = hitPosition;        // ��s���ժ���y��

                // �}�⪺ z�b - ���ժ��󪺮y�� - ���⪺�y�� (�V�q)
                transform.forward = traTestMousePosition.position - transform.position; // forward = z �b
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
