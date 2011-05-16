using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace NServiceBus.Unicast.Transport
{
	/// <summary>
	/// An envelope used by NServiceBus to package messages for transmission.
	/// </summary>
	/// <remarks>
	/// All messages sent and received by NServiceBus are wrapped in this class. 
	/// More than one message can be bundled in the envelope to be transmitted or 
	/// received by the bus.
	/// </remarks>
    [Serializable]
    [DataContract]
    public class TransportMessage
    {
		/// <summary>
		/// Gets/sets the identifier of this message bundle.
		/// </summary>
        [DataMember(Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets/sets the identifier that is copied to <see cref="CorrelationId"/>.
        /// </summary>
        [DataMember(Order = 2)]
        public string IdForCorrelation { get; set; }

		/// <summary>
		/// Gets/sets the uniqe identifier of another message bundle
		/// this message bundle is associated with.
		/// </summary>
        [DataMember(Order = 3)]
        public string CorrelationId { get; set; }

		/// <summary>
		/// Gets/sets the return address of the message bundle.
		/// </summary>
        [DataMember(Order = 4)]
        public string ReturnAddress { get; set; }

		/// <summary>
		/// Gets/sets the name of the Windows identity the message
		/// is being sent as.
		/// </summary>
        [DataMember(Order = 5)]
        public string WindowsIdentityName { get; set; }

		/// <summary>
		/// Gets/sets whether or not the message is supposed to
		/// be guaranteed deliverable.
		/// </summary>
        [DataMember(Order = 6)]
        public bool Recoverable { get; set; }

        /// <summary>
        /// Indicates to the infrastructure the message intent (publish, or regular send).
        /// </summary>
        [DataMember(Order = 7)]
        public MessageIntentEnum MessageIntent { get; set; }

        private TimeSpan timeToBeReceived = TimeSpan.MaxValue;

		/// <summary>
		/// Gets/sets the maximum time limit in which the message bundle
		/// must be received.
		/// </summary>
        [DataMember(Order = 8)]
        public TimeSpan TimeToBeReceived
        {
            get { return timeToBeReceived; }
            set { timeToBeReceived = value; }
        }

        /// <summary>
        /// Gets/sets the time that the message was sent by the source machine.
        /// </summary>
        [DataMember(Order = 9)]
        public DateTime TimeSent { get; set; }

        /// <summary>
        /// Gets/sets other applicative out-of-band information.
        /// </summary>
        [DataMember(Order = 10)]
        public List<HeaderInfo> Headers { get; set; }

        private IMessage[] body;

		/// <summary>
		/// Gets/sets the array of messages in the message bundle.
		/// </summary>
		/// <remarks>
		/// Since the XmlSerializer doesn't work well with interfaces,
		/// we ask it to ignore this data and synchronize with the <see cref="messages"/> field.
		/// </remarks>
        [XmlIgnore]
        public IMessage[] Body
        {
            get { return body; }
            set { body = value; messages = new List<object>(body); }
        }

        private Stream bodyStream;

        
		/// <summary>
		/// Gets/sets a stream to the body content of the message
		/// </summary>
		/// <remarks>
		/// Used for cases where we can't deserialize the contents.
		/// </remarks>
		[XmlIgnore]
        public Stream BodyStream
        {
            get { return bodyStream; }
            set { bodyStream = value; }
        }

        private List<object> messages;

		/// <summary>
		/// Gets/sets the list of messages in the message bundle.
		/// </summary>
        [DataMember(Order = 11)]
        public List<object> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

		/// <summary>
		/// Recreates the list of messages in the body field
		/// from the contents of the messages field.
		/// </summary>
        public void CopyMessagesToBody()
        {
            body = new IMessage[messages.Count];
            messages.CopyTo(body);
        }
    }
}
