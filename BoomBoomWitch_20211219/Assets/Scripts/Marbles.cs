using JetBrains.Annotations;
using UnityEngine;


/// <summary>
/// �u�]�t��
/// </summary>
public class Marbles : MonoBehaviour
{
    /// <summary>
    /// �����O
    /// </summary>
    public float attack;
    
    private void Awake()
    {
        // ���z API ���� �����ϼh�����I��(A�ϼh,B�ϼh) ���� A B�ϼh���I��
        Physics.IgnoreLayerCollision(6, 6);
    }
}
