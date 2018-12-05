using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBotSampleV4
{
    public class Bot : IBot
    {
        private BotAccessors _botAccessors;

        public Bot(BotAccessors botAccessors) =>
            _botAccessors = botAccessors;

        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            var welcomeUserState = await _botAccessors.WelcomeUserState.GetAsync(turnContext, () => new WelcomeUserState());

            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                if (welcomeUserState.WelcomeState == false)
                {
                    welcomeUserState.WelcomeState = true;

                    await _botAccessors.WelcomeUserState.SetAsync(turnContext, welcomeUserState);
                    await _botAccessors.ConversationState.SaveChangesAsync(turnContext);

                    var userName = turnContext.Activity.From.Name;
                    await turnContext.SendActivityAsync($"Seja bem vindo (a) {userName}!", cancellationToken: cancellationToken);
                }
                else
                    await turnContext.SendActivityAsync($"Você disse: {turnContext.Activity.Text}.", cancellationToken: cancellationToken);
            }
        }
    }
}
