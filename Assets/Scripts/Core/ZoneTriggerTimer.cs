using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class ZoneTriggerTimer: MonoBehaviour
    {
        [SerializeField] private float m_delayTime = 4f;
        [SerializeField] private string m_tagObject;
        [SerializeField] private bool m_loopAction;
        [SerializeField] private UnityEvent m_onTimerEndedAction;
        
        private bool m_isObjectInside;
        private bool m_actionDone;

        // Метод, вызываемый при входе объекта в зону
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(m_tagObject) || m_actionDone)
                return;
            
            m_isObjectInside = true;

            StartCoroutine("PerformActionCoroutine");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag(m_tagObject) || m_actionDone)
                return;
            
            StopCoroutine("PerformActionCoroutine");
            m_isObjectInside = false;
        }
        
        IEnumerator PerformActionCoroutine()
        {
            // Ждем указанное количество секунд
            yield return new WaitForSeconds(m_delayTime);

            Action();
        }

        private void Action()
        {
            m_onTimerEndedAction.Invoke();
            m_actionDone = !m_loopAction;
        }
    }
}