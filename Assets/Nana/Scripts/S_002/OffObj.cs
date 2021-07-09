using UnityEngine;

public class OffObj : MonoBehaviour
{
    [SerializeField] GameObject gameObject;

    public void SetOffObj()
    {
        gameObject.SetActive(false);
    }
}
