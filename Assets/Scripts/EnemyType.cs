using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EnemyTypeS
{
    MOB,
    ELITEMOB,
    BOSS
}
public class EnemyType : MonoBehaviour // c����� ����� ���� ��� ������ �����
{


    public Image BonusAttack;
    public int CountBonusAttack;
    public GameManager GameManager;
    public EnemyTypeS EnemyTypeS;
    void GetBonusAttack()
    {
        bool damageDealt = false;

        // �������� ����������� �� �����, ���� ������� ������ 3
        if (CountBonusAttack >= 3)
        {
            for (int i = 0; i < CountBonusAttack; i++)
            {
                BonusAttack.gameObject.SetActive(false);
            }
            CountBonusAttack = 0;
            //PlayerHP = PlayerHP - Random.Range(8, 15); �� ��� �� �����
        }

        // �������� ����������� �� �����, ���� ������� ������ 5
        if (CountBonusAttack >= 5)
        {
            for (int i = 0; i < CountBonusAttack; i++)
            {
                BonusAttack.gameObject.SetActive(false);
            }
            CountBonusAttack = 0;
            damageDealt = true;
        }

        // ��������� ����� ������, ���� ������� ������ 3 ��� 5
        if (damageDealt)
        {
            // ����� �������� ��� ��� ��������� ����� ������
        }

        // ����������� �����������, ���� ������� ������ 0
        if (CountBonusAttack > 0)
        {
            for (int i = 0; i < CountBonusAttack; i++)
            {
                BonusAttack.gameObject.SetActive(true);

            }
        }
    }




}
