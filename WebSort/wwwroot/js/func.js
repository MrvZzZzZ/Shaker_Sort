function showNotification() {
    var numbers = document.getElementById("numbersInput").value;
    var pattern = /^(\d+\s+)*\d+$/;
    if (pattern.test(numbers)) {
        SuccessSave();
    } else {
        window.alert("Ошибка: строка содержит буквы, символы или двойной пробел.");
    }
}

function SuccessSave() {
    window.alert("Массив успешно сохранен!");
}

function SuccessSorting() {
    window.alert("Массив успешно отсортирован!");
}

function SuccessDelete() {
    window.alert("Массив успешно удален!");

}