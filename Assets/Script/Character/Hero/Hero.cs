using UnityEngine;

public abstract class Hero : Character
{
    public float SkillCD { get; set; }

    public float SkillWait;
    
    protected SkillUI skillUI;
    
    protected virtual void Awake()
    {
        skillUI = FindAnyObjectByType<SkillUI>();
        
        if (skillUI == null) 
            Debug.LogWarning("ไม่เจอ SkillUI ในฉากนะ! ลืมแปะ Script หรือเปล่า?");
        
        anim = GetComponentInChildren<Animator>();
    }
    
    protected virtual void Update()
    {
        // ถ้าเจอ UI ให้ส่งข้อมูลไปบอกมัน
        if (skillUI)
        {
            // ส่ง "เวลาที่รอไปแล้ว" และ "เวลาเต็ม" ไปให้ UI คำนวณ %
            skillUI.UpdateCooldown(SkillWait, SkillCD);
        }
    }

    public void InitializeHero(int startHealth, int startDamage, int startMoveSpeed, float startAtkCD, int startAtkRange)
    {
        base.InitializeCharacter(startHealth, startDamage, startMoveSpeed, startAtkCD, startAtkRange);
        SkillWait = 10f;

    }
    public abstract void AttackType();

    public abstract void Skill();

    public override void OnDeath()
    {
        PauseSystem system = FindAnyObjectByType<PauseSystem>();
        
        if (system != null)
        {
            system.ShowGameOver();
        }
        
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        WarpPoint warp = collision.GetComponent<WarpPoint>();


        if (item)
        {
            item.AddjustPlayerStatus(this);
        }
        else if (warp) 
        {

            warp.WarpPlayer(this.gameObject);
        }


    }
    public void PlayAttackAnim()
    {
        if (anim != null)
        {
            anim.SetTrigger("Attack"); // ชื่อ "Attack" ต้องตรงกับใน Animator เป๊ะๆ
        }
    }



}
