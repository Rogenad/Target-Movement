using UnityEngine;
using UnityEngine.Events;

public class BonusTrigger : MonoBehaviour
{
   public UnityEvent bonusTriggered;

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         bonusTriggered.Invoke();
      }
   }
}
