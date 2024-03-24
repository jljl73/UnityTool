using UniRx;

namespace Mignon.Data
{
    public class UserData : DataModelBase
    {
        private ReactiveProperty<int> score = new ReactiveProperty<int>();
        public IReactiveProperty<int> Score => score;


        private ReactiveProperty<string> nickName = new ReactiveProperty<string>();
        public IReactiveProperty<string> NickName => nickName;

        public override void Init()
        {
        }

        public override void Dispose()
        {
        }
    }
}
