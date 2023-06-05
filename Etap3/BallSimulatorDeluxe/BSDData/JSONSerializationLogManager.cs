using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace BSDData
{
    public class JSONSerializationLogManager : SerializationLogManager
    {
        public JSONSerializationLogManager(string? filePath = null) : base(filePath) { }

        public override void SerializeAndStore<TObject>(TObject @object, string? name)
        {
            //throw new NotImplementedException();
            //if (title == "datetime" || title == "guid") throw new ArgumentException();


            StoredEntity<TObject> entity = new StoredEntity<TObject>(@object, name);
            
            Monitor.Enter(this);
            if (base.FileStreamWriter == null)
            {
                throw new NullReferenceException();
            }

            //string jsonText = JsonSerializer.Serialize(entity);
            string jsonText = JsonConvert.SerializeObject(entity);
            base.FileStreamWriter.WriteLine(jsonText);

            Monitor.Exit(this);
            
            

        }

        [Serializable]
        class StoredEntity<TObject> //: ISerializable
        {
            private string guid;
            private DateTime dateTime;
            private string? name;
            private TObject @object;
            public StoredEntity(TObject @object, string? name)
            {
                this.guid = Guid.NewGuid().ToString();
                this.dateTime = DateTime.Now;
                this.name = name;
                this.@object = @object;
            }
            public string GUID => this.guid;
            public DateTime DateTime => this.dateTime;
            public string? Name => this.name;
            public TObject Object => this.@object;

            /*public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue
            }*/
        }
    }
}
