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
        public abstract void SerializeAndStore<T>(T @object, string? name = null);
        public void SetDestination(string destination);
        public bool IsActive { get; }

    }
}
