// �A�C�e���̃N���X
using UnityEngine;

public class ObtainableItem : MonoBehaviour
{
    [SerializeField] Obtainable obt; // �擾�\�N���X�̃I�u�W�F�N�g

    // �A�C�e���ɐG������
    public void ClickObject()
    {
        obt.Obtain(gameObject); // �擾���\�b�h���Ă�
    }

    

}