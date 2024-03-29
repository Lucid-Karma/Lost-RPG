using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBase : MonoBehaviour
{
    public int maximum;
    public float current;
    public Image mask;
    private float fillAmount;

    public virtual void GetCurrentFill()
    {
        fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
}
