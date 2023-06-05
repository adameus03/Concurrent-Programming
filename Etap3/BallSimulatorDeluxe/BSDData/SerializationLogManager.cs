using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BSDData
{
    public abstract class SerializationLogManager : ISerializationLogManager
    {
        
        private string? filePath = null;
        private StreamWriter? fileStreamWriter = null;
        protected bool isLogging = false;

        public SerializationLogManager(string? filePath = null)
        {
            this.filePath = filePath;
        }

        public static SerializationLogManager CreateInstance(string? filePath = null)
        {
            return new JSONSerializationLogManager(filePath);
        }

        public void BeginLogging()
        {
            if(this.filePath == null)
            {
                throw new NullReferenceException();
            }

            this.fileStreamWriter = new StreamWriter(this.filePath, append: true, Encoding.UTF8);
            this.isLogging = true;
        }

        public void StopLogging()
        {
            if(this.fileStreamWriter == null)
            {
                throw new NullReferenceException();
            }

            this.fileStreamWriter.Close();
            this.isLogging = false;
        }

        public abstract void SerializeAndStore<TObject>(TObject @object, string? name = null);

        protected StreamWriter? FileStreamWriter => this.fileStreamWriter;

        public void SetDestination(string destination)
        {
            this.filePath = destination;
        }

        public string? FilePath
        {
            get
            {
                return this.filePath;
            }
            //set
            //{
            //    this.filePath = value;
                /*if(value != null)
                {
                    this.fileStreamWriter = new StreamWriter()
                }*/
            //}
        }

        public bool IsLogging => this.isLogging;
        public bool IsActive => this.isLogging;

        public class NotLoggingException : Exception
        {
            string fileName;
            public NotLoggingException(string? fileName = null)
            {
                this.fileName = fileName ?? "";
            }

            public override string Message
            {
                get
                {
                    return $"The file {this.fileName} was not meant for logging at this moment"; 
                }
            }
        }
    }
}
