using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class TeleportPoint : MonoBehaviour, ILoadable
{
    [SerializeField] private Material staticMaterial;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private float teleportDelay = 3;
    public float Progress => teleportDelay;

    private MeshRenderer _meshRenderer;
    private float _teleportDelayInitial;
    private GameObject _player;
    private bool _isActivate = false;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _teleportDelayInitial = teleportDelay;
    }

    private void Update()
    {
        if (_isActivate == false)
            return;

        teleportDelay -= Time.deltaTime;
        if (teleportDelay <= 0)
            TeleportPlayer();
    }

    public void OnPointerEnter()
    {
        _isActivate = true;
        _meshRenderer.material = activeMaterial;
    }

    public void OnPointerExit()
    {
        _isActivate = false;
        teleportDelay = _teleportDelayInitial;
        _meshRenderer.material = staticMaterial;
    }

    private void TeleportPlayer()
    {
        _player = FindObjectOfType<PlayerMobile>().gameObject;
        _player.transform.position = transform.position;
        teleportDelay = _teleportDelayInitial;
    }
}