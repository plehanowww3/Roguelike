using Data;
using UniRx;

namespace MVVM
{
    public class Model
    {
        public ReactiveProperty<bool> isAllSameType;
        public ReactiveDictionary<string, BodyPartData> m_characterParts;
        public ReactiveProperty<string> avatarType;

        public Model()
        {
            avatarType = new ReactiveProperty<string>();
            isAllSameType = new ReactiveProperty<bool>();
            m_characterParts = new ReactiveDictionary<string, BodyPartData>();
        }
    }
}