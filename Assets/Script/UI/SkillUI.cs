using UnityEngine;
using UnityEngine.UI; // ลืมบรรทัดนี้ไม่ได้นะ!

public class SkillUI : MonoBehaviour
{
    private Image overlayImage;

    void Awake()
    {
        // ดึง component Image ของตัวเองมาเก็บไว้
        overlayImage = GetComponent<Image>();
        
        // เริ่มเกมมา ให้เป็น 0 ไปก่อน (สว่าง)
        if (overlayImage != null)
            overlayImage.fillAmount = 0;
    }

    // ฟังก์ชันนี้จะคอยรับค่าจาก Hero มาอัปเดต
    public void UpdateCooldown(float currentWait, float maxCD)
    {
        if (overlayImage == null) return;

        // คำนวณอัตราส่วน:
        // currentWait คือเวลาที่ "รอมาแล้ว"
        // maxCD คือ "เวลารอทั้งหมด"
        // ถ้า currentWait = 0 แปลว่าเพิ่งใช้สกิล -> ratio = 1 (ดำเต็ม)
        // ถ้า currentWait = maxCD แปลว่าพร้อมใช้ -> ratio = 0 (สว่าง)
        
        float ratio = 1f - (currentWait / maxCD);
        
        // ป้องกันไม่ให้ค่าเกิน 0-1
        ratio = Mathf.Clamp01(ratio);

        overlayImage.fillAmount = ratio;
    }
}