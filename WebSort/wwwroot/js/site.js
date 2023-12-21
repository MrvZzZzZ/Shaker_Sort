// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateInput(textareaValue) {
    var numbers = textareaValue.split(" ");

    for (var i = 0; i < numbers.length; i++) {
        if (isNaN(numbers[i])) {
            window.alert("Пожалуйста, введите только целые числа через пробел.");
            return false;
        }
    }

    return true;
}

function handleChange() {
    var selectValue = document.getElementById("userSelect").value;
    var content = document.getElementById("content");

    switch (selectValue) {
        case 'Default':
            content.innerHTML = '';
            break;
        case 'Manual':
            content.innerHTML = '<form onsubmit="return validateInput()">'
            content.innerHTML += '<textarea id="manualInput" rows="4" cols="50" placeholder="Введите элементы массива через пробел"></textarea><br>';
            content.innerHTML += '<button onclick="getManualInput()">Submit</button>';
            content.innerHTML += '</form>'
            break;
        case 'Random':
            content.innerHTML = '<textarea id="arraySize" rows="4" cols="50" placeholder="Введите нужный размер массива от 1 до 20"></textarea><br>';
            content.innerHTML += '<button onclick="getRandomInput()">Submit</button>';
            content.innerHTML += '</form>'
            break;
        case 'FromDB':
            content.innerHTML = "Содержимое для опции 3";
            break;
    }
}

function userAction() {
    var userValue = document.getElementById("userSelect1").value;
    var contentBase = document.getElementById("contentBase");

    switch (userValue) {
        case 'Default':
            contentBase.innerHTML = 'ГонФладд';
            window.alert('Пенисы вкусные');
            break;
        case 'Add':
            contentBase.innerHTML = 'ГонФладд';
            window.alert('Пенисы вкусные');
            break;
        case 'Delete':
            contentBase.innerHTML = 'Удаление';
            break;
        case 'Modification':
            contentBase.innerHTML = "Обновление";
            break;
    }
}

function getManualInput() {
    var manualInputValue = document.getElementById("manualInput").value;
    if (validateInput(manualInputValue)) {
        outputArray.value = manualInputValue;
    }
}

function getRandomInput() {
    var arraySize = document.getElementById("arraySize").value;
    var numbers = [];

    if (arraySize < 1 || arraySize > 20 || isNaN(arraySize)) {
        window.alert("Пожалуйста, введите размера массива от 1 до 20");
        return false;
    }

    for (var i = 0; i < arraySize; i++) {
        numbers[i] = -100 + Math.floor(Math.random() * 200);
    }

    output = numbers.join(" ");
    outputArray.value = output;
}
