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
public class EnemyType : MonoBehaviour // cкорей всего этот код пойдет нахуй
{


    public Image BonusAttack;
    public int CountBonusAttack;
    public GameManager GameManager;
    public EnemyTypeS EnemyTypeS;
    void GetBonusAttack()
    {
        bool damageDealt = false;

        // Удаление изображений со сцены, если счетчик достиг 3
        if (CountBonusAttack >= 3)
        {
            for (int i = 0; i < CountBonusAttack; i++)
            {
                BonusAttack.gameObject.SetActive(false);
            }
            CountBonusAttack = 0;
            //PlayerHP = PlayerHP - Random.Range(8, 15); да иди ты нахуй
        }

        // Удаление изображений со сцены, если счетчик достиг 5
        if (CountBonusAttack >= 5)
        {
            for (int i = 0; i < CountBonusAttack; i++)
            {
                BonusAttack.gameObject.SetActive(false);
            }
            CountBonusAttack = 0;
            damageDealt = true;
        }

        // Нанесение урона игроку, если счетчик достиг 3 или 5
        if (damageDealt)
        {
            // Здесь вставьте код для нанесения урона игроку
        }

        // Отображение изображений, если счетчик больше 0
        if (CountBonusAttack > 0)
        {
            for (int i = 0; i < CountBonusAttack; i++)
            {
                BonusAttack.gameObject.SetActive(true);

            }
        }
    }




}
