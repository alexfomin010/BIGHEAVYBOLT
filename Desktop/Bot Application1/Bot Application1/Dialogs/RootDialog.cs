using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
        
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }
        
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            
            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;
            await context.PostAsync("Приветик, давай сыграем с тобой в крестики нолики?");
            // return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            if (activity.Text == "Давай")
            {
                await context.PostAsync("0|_A_|_B_|_C_|\n1|___|___|___|\n2|___|___|___|\n3|___|___|___|\nВведи координату");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}