using Csla;

namespace Business
{
    [Serializable]
    public class RandomNumberCommand : CommandBase<RandomNumberCommand>
    {
        public static readonly PropertyInfo<int> ResultProperty = RegisterProperty<int>(c => c.Result);
        public int Result
        {
            get => ReadProperty(ResultProperty);
            set => LoadProperty(ResultProperty, value);
        }

        public static RandomNumberCommand Execute()
        {
            if (!CslaBox.TryGetPortal<RandomNumberCommand>(out var portal)) return null;
            var cmd = portal.Create();
            return portal.Execute(cmd);
        }

        [Execute]
        void DoExecute()
        {
            var obj = new Random();
            Result = obj.Next();
        }
    }
}
