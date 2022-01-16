using UnityEngine;

/// <summary>
/// �^���u�]�t��
/// </summary>
public class RecycleMarble : MonoBehaviour
{
    /// <summary>
    /// �^�����u�]�ƶq
    /// </summary>
    public static int recycleMarbles;

    public GameManager gm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("�u�]"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = new Vector3(0, 0, 100);

            // �^���u�]�ƶq �W�[
            recycleMarbles++;
            // �p�G �^���ƶq ���� �i�o�g�̤j�u�]�ƶq ������ �Ĥ�^�X
            if (recycleMarbles == ControlSystem.shootMarbles) gm.SwitchTurn(false);
        }
    }
}
