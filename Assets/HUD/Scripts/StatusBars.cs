using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBars : MonoBehaviour
{

    public Image hpBarIndicator;
    public Image hpBarActual;
    public Image mpBar;

    public TMP_InputField input;

    public TextMeshProUGUI characterName;

    public int healthValue;
    private float healthValueActual;
    public int manaValue;

    public int maxHP = 75;
    public int maxMP = 23;

    public float hpChangeMultiplier = 3;

    private void Start()
    {
        healthValue = maxHP;
        healthValueActual = maxHP;
        manaValue = maxMP;
    }

    public void AdjustHealth(int value)
    {
        if (healthValue + value <= maxHP)
        {
            if (healthValue + value >= 0)
            {
                healthValue += value;
            }
            else
            {
                healthValue = 0;
            }

        }

        if (value < 0)
        {
            StopAllCoroutines();
            StartCoroutine(AdjustHealthActual());

        }
        else
        {
            healthValueActual = healthValue;
        }

    }
    public void AdjustMana(int value)
    {
        if (manaValue + value <= maxMP)
        {
            if (manaValue + value >= 0)
            {
                manaValue += value;
            }
            else
            {
                manaValue = 0;
            }

        }
    }

    public void ChangeCharacterName()
    {
        string _name = input.text;
        characterName.text = _name.ToUpper();
    }

    private void Update()
    {
        float hpFloat = healthValue;
        float mpFloat = manaValue;
  

        hpBarIndicator.fillAmount = UtilScript.RemapRange(hpFloat, 0, maxHP, 0, 1);
        hpBarActual.fillAmount = UtilScript.RemapRange(healthValueActual, 0, maxHP, 0, 1);

        mpBar.fillAmount = UtilScript.RemapRange(mpFloat, 0, maxMP, 0, 1);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            int num = Random.Range(1, (maxHP / 4));
            AdjustHealth(-num);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            int num = Random.Range(1, (maxHP / 4));
            AdjustHealth(num);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            int num = Random.Range(1, (maxMP / 4));
            AdjustMana(num);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            int num = Random.Range(1, (maxMP / 4));
            AdjustMana(-num);
        }
    }

    public IEnumerator AdjustHealthActual()
    {
        float elapsedTime = 0;
        float duration = Mathf.Abs(healthValueActual- healthValue) / maxHP;
        float startValue = healthValueActual;
        yield return new WaitForSeconds(1);

        while (elapsedTime < duration)
        {
            healthValueActual = Mathf.Lerp(startValue, healthValue, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        healthValueActual = healthValue;


    }
}
