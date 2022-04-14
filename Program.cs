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
            url: "https://github.com/TimofejKolomin/BOTPANTHEON"
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
        text: "Список команд: /help , /hello , /link, /delkey , /buttons"
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

// ----- BUTTONS ----- //
var buttons = update.Message;
if(buttons.Text.ToLower() == "/buttons")
{
    await bot.SendTextMessageAsync
    (
        chatId: chatID,
        text: "Нажмите на кнопку",
        disableNotification: true,
        replyToMessageId: update.Message.MessageId,
        replyMarkup: new ReplyKeyboardMarkup
        (
            new[]
            {
                new KeyboardButton[] { "Один", "Два" },
                new KeyboardButton[] { "Три", "Четыре" },
            }
        ),
        cancellationToken: cancellationToken
    );
}

// ----- ONE BUTTON ----- //
var One = update.Message;
if(One.Text == "Один")
{
    await bot.SendPhotoAsync
    (
       chatId: chatID,
       photo: "https://github.com/TimofejKolomin/ResForPantheonBot/blob/main/08834b22-44d1-402c-90e0-b901b0f436c6.jpg?raw=true",
       parseMode: ParseMode.MarkdownV2,
       caption: "Фото профиля бота",
       replyToMessageId: update.Message.MessageId,
       cancellationToken: cancellationToken
    );
}

// ----- TWO BUTTON ----- //
var Two = update.Message;
if(Two.Text == "Два")
{
    await bot.SendVideoAsync
    (
        chatId: chatID,
        video: "https://github.com/TimofejKolomin/ResForPantheonBot/blob/main/957cb7e8-f10f-40b8-bbc3-c23fc8cb91da.mp4?raw=true",
        supportsStreaming: true,
        parseMode: ParseMode.MarkdownV2,
        replyToMessageId: update.Message.MessageId,
        cancellationToken: cancellationToken
    );
}

// ----- THREE BUTTON ----- //
var Three = update.Message;
if(Three.Text == "Три")
{
    await bot.SendDiceAsync
    (
        chatId: chatID,
        emoji: Emoji.Dice,
        replyToMessageId: update.Message.MessageId,
        cancellationToken: cancellationToken
    );
}

// ----- FOUR BUTTON ----- //
var Four = update.Message;
if(Four.Text == "Четыре")
{
    await bot.SendAnimationAsync
    (
        chatId: chatID,
        animation: "https://github.com/TimofejKolomin/ResForPantheonBot/blob/main/921836ea-8756-4d43-9974-c485946367df-_1_.gif?raw=true",
        width: 50,
        height: 50,
        replyToMessageId: update.Message.MessageId,
        cancellationToken: cancellationToken
    );
}

// ----- STARTCOMMAND ----- //
var Start = update.Message;
if(Start.Text.ToLower() == "/start")
{
    await bot.SendTextMessageAsync(chatId: chatID, text: "Для того чтобы посмотреть команды бота - введите команду /help", cancellationToken: cancellationToken);
}


}

async Task HandlerErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cancellationToken)
{
    System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
}
