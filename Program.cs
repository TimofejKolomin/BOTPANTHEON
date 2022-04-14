using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types.ReplyMarkups;



ITelegramBotClient bot = new TelegramBotClient("5277173467:AAGQgOknOiSNQCBHPlvlDP7g9P7aNAnTaZU");
System.Console.WriteLine("Бот Активирован" + bot.GetMeAsync().Result.FirstName);
var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var receiverOpton = new ReceiverOptions{ AllowedUpdates = {},};
bot.StartReceiving(HandlerUpdateAsync, HandlerErrorAsync, receiverOpton, cancellationToken);
System.Console.ReadLine();
// ITelegramBotClient bot = new TelegramBotClient("5277173467:AAGQgOknOiSNQCBHPlvlDP7g9P7aNAnTaZU");
async Task HandlerUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)



// ----- HELLO ----- //
{
    if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
    {
         var message = update.Message;
         var firstName = update.Message.From.FirstName;
        if(message.Text.ToLower() == "/hello")
        {
            await bot.SendTextMessageAsync(message.Chat, "Здраствуй, " + firstName);
        }
    }
    var chatID = update.Message.Chat.Id;
// ----- LINK MESSAGE1 ----- //    
InlineKeyboardMarkup inlineKeyboard = new
(
    new []
    { 
        InlineKeyboardButton.WithUrl
        (
            text: "❗ Нажми на меня ❗",
            url: "https://github.com/TimofejKolomin/botPantheon"
        )
    }
);
// ----- LINK MESSAGE2 ----- //
var linkMessage = update.Message; 
if(linkMessage.Text.ToLower() == "/link")
    {
        await bot.SendTextMessageAsync
        (
        chatId: chatID,
        text: "Код от бота",
        replyMarkup: inlineKeyboard,
        cancellationToken: cancellationToken
        );
    }
var helpMessage = update.Message;
if(helpMessage.Text.ToLower() == "/help")
{
    await bot.SendTextMessageAsync
    (
        chatId: chatID,
        text: "Список команд: /help , /hello , /link, /delkey"
    );
}
// ----- ❌DELETEKEYBOARD❌ ----- //
var deleteKeyboard = update.Message;
if(deleteKeyboard.Text.ToLower() == "/delkey")
{
    await bot.SendTextMessageAsync
    (
        chatId: chatID,
        text: "Удаление клавиатуры",
        replyMarkup: new ReplyKeyboardRemove(),
        cancellationToken: cancellationToken
    );    
}           


// ----- BUTTONHELP ----- //





}

async Task HandlerErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
{
    System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
}
