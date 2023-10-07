const iframeId = "chat";
const iframeSelector = "#" + iframeId;
var messageInputFocus = false;

$().ready(function () {
    const messageInput = $(".send-message-area-text");

    messageInput.on("focus", () => { messageInputFocus = true; })
    messageInput.on("focusout", () => { messageInputFocus = false; })
})


function OnGetChatBtnClick() {
    const chatName = $(".chat-name-area-text").val();

    if (chatName == "")
        return;

    GetChatHTML(chatName);
}

function GetChatHTML(chatName) {
    const getHtmlUrl = "https://localhost:7292/GetChatHTML";

    $.ajax({
        type: "POST",
        url: getHtmlUrl,
        data: JSON.stringify({ ChatName: chatName }),
        headers: { "Content-Type": "application/json" },
        success: (data) => {
            let ifrmWindow = $(iframeSelector)[0].contentWindow;
            ifrmWindow.document.open();
            ifrmWindow.document.close();

            $(iframeSelector).contents().find('html').html(data);

            const offset = 999_999_999_999_999;
            $(ifrmWindow).scrollTop(offset);
        },
        error: () => {
            alert("Something wrong with get chat request :(");
        },
    });
}

function OnSendMessageClick() {
    //var status = $(".chat-status").text();
    var message = $(".send-message-area-text").val();

    if (message == "")
        return;

    SendMessage(message);
}

function SendMessage(message) {
    const sendMessageUrl = "https://localhost:7292/SendMessage";

    const chatName = $(".chat-name-area-text").val();
    //const chatName = $(".chat-room-name").val();

    let nickname = $(".nickname-area-text").val();

    let data = JSON.stringify({
        ChatName: chatName,
        Content: message,
        NickName: nickname
    });

    $.ajax({
        type: "POST",
        url: sendMessageUrl,
        data: data,
        headers: { "Content-Type": "application/json" },
        success: (data) => {
            GetChatHTML(chatName);
            $(".send-message-area-text").val("");
        },
        error: () => {
            alert("Something wrong with send message request :(");
        },
    });
}

document.addEventListener('keyup', event => {
    if (event.code === 'Enter' && messageInputFocus)
        OnSendMessageClick();
});
