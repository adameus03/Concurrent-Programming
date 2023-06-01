using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    public abstract class BSDAbstractDataAPI
    {
        public BSDAbstractDataAPI() { }
        public static BSDAbstractDataAPI CreateInstance()
        {
            return new BSDDataAPI();
        }

        public abstract IConstraintManager GetConstraintManager();
        public abstract ISerializationLogManager GetSerializationLogManager();

        public abstract void UploadDataCouple(object dataCoupleElement1, object dataCoupleElement2, string? name);

        public void SetLoggingPath(string path)
        {
            this.GetSerializationLogManager().SetDestination(path);
        }
        public void StartLogging()
        {
            this.GetSerializationLogManager().BeginLogging();
        }
        public void PauseLogging()
        {
            this.GetSerializationLogManager().StopLogging();
        }


    }
}
