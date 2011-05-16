using System;
using System.Runtime.Serialization;

namespace NServiceBus.Grid.Messages
{
    /// <summary>
    /// Response message returned by the bus
    /// as a result of a <see cref="GetNumberOfWorkerThreadsMessage"/>.
    /// </summary>
    [Serializable]
    [DataContract]
    public class GotNumberOfWorkerThreadsMessage : IMessage
    {
        /// <summary>
        /// The number of worker threads running on the sending endpoint.
        /// </summary>
        [DataMember(Order=1)]
        public int NumberOfWorkerThreads { get; set; }
    }
}
