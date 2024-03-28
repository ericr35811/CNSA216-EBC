var txtEnteredDateTime = <%  %>

function Updatetime() {
    txtEnteredDateTime.value = new Date().toLocaleString();
}

var intervalTime = window.setInterval(Updatetime, 1000);