using UnityEngine;

public class Marbles : MonoBehaviour
{
    private void Awake()
    {
        // ���z API ���� �����ϼh�����I��(A�ϼh,B�ϼh) ���� A B�ϼh���I��
        Physics.IgnoreLayerCollision(6, 6);
    }
}
