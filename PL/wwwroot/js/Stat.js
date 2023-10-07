async function OnReloadButtonClick() {
    const roomsAmount = $("#ChatRoomsAmount");
    const messagesAmount = $("#ChatMessagesAmount");

    roomsAmount.text("");
    messagesAmount.text("");

    const url = '/GetStat'
    const responce = await fetch(url, {
        method: 'GET'
    });

    if (responce.ok) {
        const stat = await responce.json();

        roomsAmount.text(stat.chatRoomsAmount);
        messagesAmount.text(stat.chatMessagesAmount);
    }
    else alert("Something wrong with /GetStat :(");
}