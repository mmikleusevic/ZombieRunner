using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas _impactCanvas;
    [SerializeField] float _impactTime = 0.3f;

    private void Start()
    {
        _impactCanvas.enabled = false;
    }

    public async Task ShowDamageImpact()
    {
        await ShowSplatter();
    }

    public async Task ShowSplatter()
    {
        _impactCanvas.enabled = true;
        await Awaitable.WaitForSecondsAsync(_impactTime);
        _impactCanvas.enabled = false;
    }
}
