using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    public interface ISerializationLogManager
    {
        public void BeginLogging();
        public void StopLogging();
        public abstract void SerializeAndStore(object @object, string? name = null);
        public void SetDestination(string destination);

    }
}
