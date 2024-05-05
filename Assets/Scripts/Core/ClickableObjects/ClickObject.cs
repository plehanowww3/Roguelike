using UnityEngine;
using UnityEngine.Events;

namespace Core.ClickableObjects
{
    public class ClickObject: MonoBehaviour, IClickableObject
    {
        [SerializeField] private int m_clicksToAction;
        [SerializeField] private bool m_loopingAction;
        [SerializeField] private UnityEvent m_actions;

        private int m_clicks;

        // Метод, вызываемый при клике на объекте
        public void OnClickAction()
        {
            if (!m_loopingAction && m_clicks >= m_clicksToAction)
                return;
            
            m_clicks++;

            if (m_clicks >= m_clicksToAction)
            {
                m_actions.Invoke();
                if (m_loopingAction)
                    m_clicks = 0;
            }

            Debug.Log("Кликнули по объекту: " + gameObject.name);
        }
    }
}