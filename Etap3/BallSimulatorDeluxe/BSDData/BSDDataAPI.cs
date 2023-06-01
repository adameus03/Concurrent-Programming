using System.Diagnostics;

namespace BSDData
{
    class BSDDataAPI : BSDAbstractDataAPI
    {
        BasicConstraintManager basicConstraintManager = new BasicConstraintManager();
        SerializationLogManager serializationLogManager;
        public BSDDataAPI() : base() {
            this.serializationLogManager = SerializationLogManager.CreateInstance();
        }

        public override BasicConstraintManager GetConstraintManager()
        {
            return this.basicConstraintManager;
        }

        public override SerializationLogManager GetSerializationLogManager()
        {
            return this.serializationLogManager;
        }

        public override async void UploadDataCouple<T>(T dataCoupleElement1, T dataCoupleElement2, string? name)
        {
            if (this.serializationLogManager.IsLogging)
            {
                await Task.Run(()=>serializationLogManager.SerializeAndStore((dataCoupleElement1, dataCoupleElement2), name));
            }
            else throw new SerializationLogManager.NotLoggingException(serializationLogManager.FilePath);
        }
    }
}