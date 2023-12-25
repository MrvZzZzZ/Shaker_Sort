function showNotification() {
    var numbers = document.getElementById("numbersInput").value;
    var pattern = /^(\d+\s+)*\d+$/;
    if (pattern.test(numbers)) {
        SuccessAdd();
    } else {
        window.alert("Ошибка: строка содержит буквы, символы или двойной пробел.");
    }
}

function SuccessAdd() {
    window.alert("Массив успешно добавлен!");
}

function SuccessSorting() {
    window.alert("Массив успешно отсортирован!");
}

function SuccessEdit() {
    window.alert("Массив успешно изменен!");

}
function SuccessDelete() {
    window.alert("Массив успешно удален!");

}