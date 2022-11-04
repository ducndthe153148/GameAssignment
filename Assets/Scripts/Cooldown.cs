using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;

    private bool isCooldown = false;
    [SerializeField]
    private float cooldownTime;
    private float cooldownTimer = 0.0f;
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
        btn = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        UseSpell();
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;        
        if(cooldownTimer < 0.0f)
        {
            //isCooldown = false ;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
            btn.enabled = true;
            btn.onClick.AddListener(AfterOnClick);
        } else
        {
            btn.enabled = false;
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    void AfterOnClick()
    {
        isCooldown = false;
    }

    public void UseSpell()
    {
        if (isCooldown)
        {
            
        } else
        {           
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        }
    }
}
