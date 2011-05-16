using System;
using System.Runtime.Serialization;

namespace NServiceBus.Grid.Messages
{
    /// <summary>
    /// Message sent to request that the bus change the number of
    /// worker threads handling messages. 
    /// </summary>
    [Serializable]
    [DataContract]
    public class ChangeNumberOfWorkerThreadsMessage : IMessage
    {
        /// <summary>
        /// Target number of worker threads.
        /// </summary>
        [DataMember(Order=1)]
        public int NumberOfWorkerThreads { get; set; }
    }
}
