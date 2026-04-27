using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    protected virtual void Awake()
    {
        //if (characterHealthManager == null) characterHealthManager = GetComponent<CharacterHealthManager>();
    }

    public void HandleDamage(int damage)
    {
        //Debug.Log($"{gameObject.name} takes {damage} damage.");
        //characterHealthManager.TakeDamage(damage);
    }
}
