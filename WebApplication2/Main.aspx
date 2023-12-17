<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="ShakerSort.cs" Inherits="WebApplication2.Main"  %>

<!DOCTYPE html>

<html xmlns="http://www.ShakerSort.org/">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="C:\Users\Антон\Desktop\WebApplication2\ShakerSort.dll" type="text/csharp"></script>
        <script>
        
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
            var selectValue = document.getElementById("UserSelect").value;
            var content = document.getElementById("content");

            switch (selectValue){
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
                    content.innerHTML = "Содержимое для опции 2";
                    break;
                case 'FromDB':
                    content.innerHTML = "Содержимое для опции 3";
                    break;
                case 'FromFile':
                    content.innerHTML = "Содержимое для опции 4";
                    break;
            }
        }

        function getManualInput() {
            var manualInputValue = document.getElementById("manualInput").value;
            if (validateInput(manualInputValue)) {
                var myList = [];
                for (var i = 0; i < manualInputValue.length; i++) {
                    var number = parseFloat(numberList[i]);
                    myList.push(number);
                }                
                var sortingNumbers
                var result = PageMethods.RunShakerSort(myList, onServerFunctionSuccess, onServerFunctionFailure);
                for (var i = 0; i < myList.length; i++) {
                    sortingNumbers += result[i] + " ";
                }
                outputArray.value = manualInputValue;
            }          
        }

        function onServerFunctionSuccess(result) {
            // обработка успешного вызова серверной функции
            alert(result);
        }

        function onServerFunctionFailure(error) {
            // обработка ошибки при вызове серверной функции
            alert("Ошибка: " + error.get_message());
        }
        </script>

</head>

<body>
    <form id="form1" runat="server">
        <div>

            <h1>Шейкерная сортировка</h1>
            <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Сортировка миксером, или Шейкерная сортировка, или двунаправленная (англ. CockTail sort) — разновидность пузырьковой сортировки. Анализируя метод пузырьковой сортировки, можно отметить два обстоятельства.
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Во-первых, если при движении по части массива перестановки не происходят, то эта часть массива уже отсортирована и, следовательно, её можно исключить из рассмотрения.
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Во-вторых, при движении от конца массива к началу минимальный элемент «всплывает» на первую позицию, а максимальный элемент сдвигается только на одну позицию вправо.
            <br>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Эти две идеи приводят к следующим модификациям в методе пузырьковой сортировки. Границы рабочей части массива (то есть части массива, где происходит движение) устанавливаются в месте последнего обмена на каждой итерации. Массив просматривается поочередно справа налево и слева направо.
            </p>

            <h2>
                Ввод
            </h2>
            <p>Выберите способ заполнения массива:
                <select id="UserSelect" name="UserSelect" onchange="handleChange()">
                    <option value="Default">-Способы ввода-</option>
                    <option value="Manual">Вручную</option>
                    <option value="Random">Случайными числами</option>
                    <option value="FromDB">Загрузить с базы данных</option>
                    <option value="FromFile">Загрузить с файла</option>
                </select>
            </p>
        </div>
    </form>

    <div id="content">
    </div>

    <div>
        <h2>
            Вывод
        </h2>
        <p>
            <textarea id="outputArray"  rows="4" cols="50" placeholder="Здесь выведется отсортированный массив" readonly="true"></textarea>
        </p>
    </div>      

</body>
</html>

