using UnityEngine;

public class BlinkDefault : MonoBehaviour, IBlink
{
    [SerializeField] private GameObject BlinkPrefab;

    public void BlinkDown()
    {
        GameObject blinkGameObj = Instantiate(BlinkPrefab, transform.position, Quaternion.identity);

        var vo = blinkGameObj.GetComponentInChildren<ParticleSystem>().velocityOverLifetime;
        var fo = blinkGameObj.GetComponentInChildren<ParticleSystem>().forceOverLifetime;

        vo.x = new ParticleSystem.MinMaxCurve(-2f - GetComponent<PlayerController>().GetSpeed(), 2f - GetComponent<PlayerController>().GetSpeed());
        fo.y = new ParticleSystem.MinMaxCurve(-5f);
        vo.y = new ParticleSystem.MinMaxCurve(5f, 7f);

        DoBlink(blinkGameObj);
    }

    public void BlinkUp()
    {
        GameObject blinkGameObj = Instantiate(BlinkPrefab, transform.position, Quaternion.identity);

        var vo = blinkGameObj.GetComponentInChildren<ParticleSystem>().velocityOverLifetime;
        var fo = blinkGameObj.GetComponentInChildren<ParticleSystem>().forceOverLifetime;

        vo.x = new ParticleSystem.MinMaxCurve(-2f - GetComponent<PlayerController>().GetSpeed(), 2f - GetComponent<PlayerController>().GetSpeed());
        fo.y = new ParticleSystem.MinMaxCurve(5f);
        vo.y = new ParticleSystem.MinMaxCurve(-5f, -7f);

        DoBlink(blinkGameObj);
    }

    private void DoBlink(GameObject blinkgameobject)
    {
        if (BlinkPrefab != null)
        {
            blinkgameobject.GetComponentInChildren<ParticleSystem>().Play();
        }
        else
        {
            Debug.LogError("Blink prefab or particle system is empty");
        }
    }
}
