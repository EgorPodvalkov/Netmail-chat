async function OnReloadButtonClick() {
    const roomsAmount = $("#ChatRoomsAmount");
    const messagesAmount = $("#ChatMessagesAmount");
    const articlesAmount = $("#ArticlesAmount");

    roomsAmount.text("");
    messagesAmount.text("");

    const url = '/GetStatJSON'
    const responce = await fetch(url, {
        method: 'GET'
    });

    if (responce.ok) {
        const stat = await responce.json();

        roomsAmount.text(stat.chatRoomsAmount);
        messagesAmount.text(stat.chatMessagesAmount);
        articlesAmount.text(stat.articlesAmount);
    }
    else alert("Something wrong with /GetStat :(");
}