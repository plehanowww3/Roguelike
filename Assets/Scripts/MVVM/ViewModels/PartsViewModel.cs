using System.Linq;
using Data;
using ScriptableObjects;
using UniRx;

namespace MVVM.ViewModels
{
    public class PartsViewModel
    {
        public ReactiveProperty<BodyPartData> m_headPartData;
        public ReactiveProperty<BodyPartData> m_bodyPartData;
        public ReactiveProperty<BodyPartData> m_rightHandPartData;
        public ReactiveProperty<BodyPartData> m_leftHandPartData;

        private PartsScriptableObject m_partsScriptableObject;
        
        public void SetHeadPart(string _partId)
        {
            m_headPartData.Value = m_partsScriptableObject.head.FirstOrDefault(x => x.id.Equals(_partId));
        }
        public PartsViewModel()
        {
            
        }
    }
}