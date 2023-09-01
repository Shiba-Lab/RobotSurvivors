using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    //�ݒ�p��HP
    [SerializeField] private float hp = 10;
    //���݂�HP
    [NonSerialized] public float currentHp;
    //HP��\������UI
    [SerializeField] private GameObject hpBar;
    //HP�o�[�̃|�W�V����
    [SerializeField] private Transform barPoz;

    private Image hpBarImage;

    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
    }

    private void CreateHealthBar()
    {
        //�������Đe�I�u�W�F�N�g��ݒ肷��
        GameObject newBar = Instantiate(hpBar, barPoz.position, Quaternion.identity);
        newBar.transform.SetParent(transform);
        //newBar����ϐ���HP�o�[���i�[����
        EnemyHpBar healthBar = newBar.GetComponent<EnemyHpBar>();
        //�摜��ϐ��Ɋi�[����
        hpBarImage = healthBar.hpBarImage;
        //HP���X�V����
        currentHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        //�N���b�N������_���[�W���󂯂�
        if (Input.GetMouseButtonDown(0))
        {
            ReduceHP(5);
        }
        //HP�o�[�̕\�����X�V����
        hpBarImage.fillAmount = Mathf.Lerp(hpBarImage.fillAmount, currentHp / hp, Time.deltaTime * 10f);
    }

    /// <summary>
    /// HP�����炷
    /// </summary>
    /// <param name="damage"></param>
    public void ReduceHP(float damage)
    {
        currentHp -= damage;

        //����ł��邩�̔���
        DeathCheck();

    }

    /// <summary>
    /// HP��0�ɂȂ��Ă��邩�̃`�F�b�N
    /// </summary>
    private void DeathCheck()
    {
        if (currentHp <= 0)
        {
            currentHp = 0;

            //��\���ɂ���
            gameObject.SetActive(false);

        }
    }
}
