using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public Portal otherPortal;

    bool isEnabled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isEnabled)
        {
            var pos = otherPortal.transform.position;
            pos.y = other.transform.position.y;

            var cc = other.GetComponent<CharacterController>();
            if (cc != null) {
                cc.enabled = false;
                other.transform.position = pos;
                other.transform.forward = otherPortal.transform.forward;
                cc.enabled = true;
            }

            otherPortal.SetEnabled(false);
        }
    }

    public void SetEnabled(bool state)
    {
        isEnabled = state;
    }

    private void OnTriggerExit(Collider other)
    {
        isEnabled = true;
    }
}
