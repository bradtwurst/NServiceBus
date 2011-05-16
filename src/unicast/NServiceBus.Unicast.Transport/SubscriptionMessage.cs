using System;
using System.Runtime.Serialization;

namespace NServiceBus.Unicast.Transport
{
	/// <summary>
	/// A message representing a subscribe/unsubscribe request to receive messages
	/// of a specific type.
	/// </summary>
    [Serializable]
    [DataContract]
    public class SubscriptionMessage : IMessage
    {
		/// <summary>
		/// Initializes a new SubscriptionMessage.
		/// </summary>
        public SubscriptionMessage() { }

		/// <summary>
		/// Initializes a new SubscriptionMessage for the specified message type
		/// that indicates whether to add or remove a subscription.
		/// </summary>
		/// <param name="typeName"></param>
		/// <param name="subscriptionType"></param>
        public SubscriptionMessage(string typeName, SubscriptionType subscriptionType)
        {
            TypeName = typeName;
            SubscriptionType = subscriptionType;
        }

		/// <summary>
		/// Gets/sets the name of the message type to subscribe to or 
		/// unsubscribe from.
		/// </summary>
        [DataMember(Order = 1)]
        public string TypeName { get; set; }

		/// <summary>
		/// Gets/sets whether the SubscriptionMessage is to add or
		/// remove a subscription.
		/// </summary>
        [DataMember(Order = 2)]
        public SubscriptionType SubscriptionType { get; set; }
    }

	/// <summary>
	/// Describes subscription message types.
	/// </summary>
    public enum SubscriptionType 
	{ 
		/// <summary>
		/// Add a subscription.
		/// </summary>
		Add, 

		/// <summary>
		/// Remove a subscription.
		/// </summary>
		Remove 
	}
}
