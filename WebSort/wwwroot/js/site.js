// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateInput(textareaValue) {
    var numbers = textareaValue.split(" ");

    if (numbers.length > 20) {
        window.alert("Пожалуйста, введите массив длинной меньше 20 чисел");
        return false;
    }

    for (var i = 0; i < numbers.length; i++) {
        if (isNaN(numbers[i])) {
            window.alert("Пожалуйста, введите только целые числа через пробел.");
            return false;
        }
    }

    return true;
}

function handleChange() {
    var selectValue = document.getElementById("UserSelect").value;
    var content = document.getElementById("content");

    switch (selectValue) {
        case 'Default':
            content.innerHTML = '';
            break;
        case 'Manual':
            content.innerHTML = '<form onsubmit="return validateInput()">'
            content.innerHTML += '<textarea id="manualInput" rows="4" cols="50" placeholder="Введите не более 20 элементов массива через пробел"></textarea><br>';
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
    var selectChoise = document.getElementById("UserSelect1").value;
    var contentBD = document.getElementById("contentBD");

    switch (selectChoise) {
        case 'Default':
            contentBD.innerHTML = '1';
            break;
        case 'Add':
            contentBD.innerHTML = '2';
            break;
        case 'Delete':
            contentBD.innerHTML = '3';
            break;
        case 'Modification':
            contentBD.innerHTML = '4';
            break;
    }
}

function AddArray() {
    var newArray = document.getElementById('AddArray').value; // Получаем значение из поля ввода
    var data = JSON.stringify({ array: newArray }); // Преобразуем его в формат JSON
    
    $.ajax({
        type: 'POST',
        url: '/HomeController', // Путь к вашему контроллеру и методу
        data: data,
        contentType: 'application/json',
        success: function (response) {
            // Обработка успешного ответа от сервера
            console.log(response.message);
            // Обновление информации на странице, если необходимо
        },
        error: function (error) {
            // Обработка ошибок при отправке данных на сервер
            console.error('Произошла ошибка при добавлении массива в базу данных: ' + error);
        }
    });
}

function getManualInput() {
    var manualInputValue = document.getElementById("manualInput").value;
    var output;
    var numbersArray;
    if (validateInput(manualInputValue)) {
        numbersArray = manualInputValue.split(" ");

        for (var i = 0; i < numbersArray.length; i++) {
            numbersArray[i] = parseInt(numbersArray[i]);
        }

        output = runShakerSort(numbersArray);

        output = output.join(" ");

        outputArray.value = output;
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

    output = runShakerSort(numbers);

    output = numbers.join(" ");

    outputArray.value = output;
}

function runShakerSort(numbers) {
    let isSwap;
    let rightBoarder = numbers.length - 1;
    let leftBoarder = 0;
    var temp;

    do {
        isSwap = false;

        for (let i = leftBoarder; i < rightBoarder; i++) {
            if (numbers[i] > numbers[i + 1]) {
                temp = numbers[i];
                numbers[i] = numbers[i + 1];
                numbers[i + 1] = temp;
                isSwap = true;
            }
        }

        rightBoarder--;

        if (!isSwap) {
            break;
        }

        isSwap = false;

        for (let i = rightBoarder; i > leftBoarder; i--) {
            if (numbers[i] < numbers[i - 1]) {
                temp = numbers[i];
                numbers[i] = numbers[i - 1];
                numbers[i - 1] = temp;
                isSwap = true;
            }
        }

        if (!isSwap) {
            break;
        }

        leftBoarder++;
    } while (leftBoarder < rightBoarder);

    return numbers;
}