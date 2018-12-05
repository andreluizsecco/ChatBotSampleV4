using Microsoft.Bot.Builder;
using System;

namespace ChatBotSampleV4
{
    public class BotAccessors
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WelcomeUserStateAccessors"/> class.
        /// Contains the <see cref="UserState"/> and associated <see cref="IStatePropertyAccessor{T}"/>.
        /// </summary>
        /// <param name="userState">The state object that stores the counter.</param>
        public BotAccessors(ConversationState conversationState)
        {
            ConversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }

        /// <summary>
        /// Gets the <see cref="IStatePropertyAccessor{T}"/> name used for the <see cref="BotAccessors.WelcomeUserState"/> accessor.
        /// </summary>
        /// <remarks>Accessors require a unique name.</remarks>
        /// <value>The accessor name for the WelcomeUser state.</value>
        public static string WelcomeUserName { get; } = $"{nameof(BotAccessors)}.WelcomeUserState";

        /// <summary>
        /// Gets or sets the <see cref="IStatePropertyAccessor{T}"/> for DidBotWelcome.
        /// </summary>
        /// <value>
        /// The accessor stores if the bot has welcomed the user or not.
        /// </value>
        public IStatePropertyAccessor<WelcomeUserState> WelcomeUserState { get; set; }

        /// <summary>
        /// Gets the <see cref="ConversationState"/> object for the conversation.
        /// </summary>
        /// <value>The <see cref="ConversationState"/> object.</value>
        public ConversationState ConversationState { get; }
    }
}
