using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
    [SerializeField] FloatVariable damageReductionPercentage;
    [SerializeField] FloatVariable defenseCooldown;
    [SerializeField] FloatVariable defenseDuration;
    [SerializeField] GameObject playerManagerGO;

    [SerializeField] Image healthBar;

    private bool active;

    private float lastDefenseTime;
    private float totalWaitBetweenDefenseTime;

    private bool isDefending;

    private PlayerManager playerManager;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        playerManager = playerManagerGO.GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        active = false;
        isDefending = false;
        totalWaitBetweenDefenseTime = defenseCooldown.RuntimeValue + defenseDuration.RuntimeValue;
        healthBar.color = Color.green;
    }


    void Update()
    {
        if (!active) return;
        DefenseLoop(); 
    }

    private void DefenseLoop()
    {
        if ((Time.time < lastDefenseTime + totalWaitBetweenDefenseTime)) return;

        Defend();
        
    }

    private void Defend()
    {
        // change player damage reduction
        StartCoroutine(DefenseCoroutine());
        //StopCoroutine(DefenseCoroutine());  
    }

    IEnumerator DefenseCoroutine()
    {
        Debug.Log("Started defending");
        // define new lastdefense time
        lastDefenseTime = Time.time;
        totalWaitBetweenDefenseTime = defenseCooldown.RuntimeValue + defenseDuration.RuntimeValue;

        isDefending = true;
        animator.SetBool("IsDefending", isDefending);
        // make healthbar grey
        ChangeHealthBarColor(Color.grey);

        // activates damage reduction
        playerManager.ActivateDamageReduction();
        yield return new WaitForSeconds(defenseDuration.RuntimeValue);
        playerManager.DeactivateDamageReduction();

        // color of healthbar to green
        ChangeHealthBarColor(Color.green);
        

        isDefending = false;
        animator.SetBool("IsDefending", isDefending);
        Debug.Log("Stopped defending.");
    }

    public void SetActive(bool b)
    {
        active = b;
    }

    private void ChangeHealthBarColor(Color c)
    {
        healthBar.color = c;
    }
}
