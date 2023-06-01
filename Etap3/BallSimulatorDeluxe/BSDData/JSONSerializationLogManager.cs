using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BSDData
{
    internal class JSONSerializationLogManager : SerializationLogManager
    {
        public JSONSerializationLogManager(string? filePath = null) : base(filePath) { }

        public override void SerializeAndStore(object @object, string? name)
        {
            //throw new NotImplementedException();
            //if (title == "datetime" || title == "guid") throw new ArgumentException();


            StoredEntity entity = new StoredEntity(@object, name);
            
            Monitor.Enter(this);
            if (base.FileStreamWriter == null)
            {
                throw new NullReferenceException();
            }
            
            string jsonText = JsonSerializer.Serialize(entity);
            base.FileStreamWriter.WriteLine(jsonText);

            Monitor.Exit(this);
            
            

        }

        [Serializable]
        class StoredEntity //: ISerializable
        {
            private string guid;
            private DateTime dateTime;
            private string? name;
            private object @object;
            public StoredEntity(object @object, string? name)
            {
                this.guid = Guid.NewGuid().ToString();
                this.dateTime = DateTime.Now;
                this.@object = @object;
            }
            public string GUID => this.guid;
            public DateTime DateTime => this.dateTime;
            public string? Name => this.name;
            public object Object => this.@object;

            /*public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue
            }*/
        }
    }
}
