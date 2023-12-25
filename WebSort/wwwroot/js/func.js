function showNotification() {
    var numbers = document.getElementById("numbersInput").value;
    var pattern = /^(\d+\s+)*\d+$/;
    if (pattern.test(numbers)) {
    } else {
        window.alert("Ошибка: строка содержит буквы, символы или двойной пробел.");
    }
}