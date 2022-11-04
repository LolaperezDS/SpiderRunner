using UnityEngine;

public class AutoStopAndDeletePS : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_ParticleSystem;
    public float time_of_animation = 1f;
    private void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        Invoke(nameof(AutoDelete), time_of_animation);
    }

    private void AutoDelete()
    {
        m_ParticleSystem.Stop();
        m_ParticleSystem.Clear();
        Destroy(transform.parent.gameObject);
    }
}
