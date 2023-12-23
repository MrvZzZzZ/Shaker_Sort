namespace Shaker
{
    /// <summary>
    /// Класс с сортировкой
    /// </summary>
    internal class ShakerSort
    {
        private List<int> _numbers;

        public ShakerSort(List<int> numbers)
        {
            _numbers = numbers;
        }

        /// <summary>
        /// Запуск шейкерной сортировки
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        public List<int> RunShakerSort()
        {
            bool isSwap;
            int rightBoarder = _numbers.Count - 1;
            int leftBoarder = 0;

            do
            {
                isSwap = false;

                for (int i = leftBoarder; i < rightBoarder; i++)
                {
                    if (_numbers[i] > _numbers[i + 1])
                    {
                        (_numbers[i + 1], _numbers[i]) = (_numbers[i], _numbers[i + 1]);
                        isSwap = true;
                    }
                }

                rightBoarder--;

                if (!isSwap)
                    break;

                isSwap = false;

                for (int i = rightBoarder; i > leftBoarder; i--)
                {
                    if (_numbers[i] < _numbers[i - 1])
                    {
                        (_numbers[i - 1], _numbers[i]) = (_numbers[i], _numbers[i - 1]);
                        isSwap = true;
                    }
                }

                if (!isSwap)
                    break;

                leftBoarder++;
            }
            while (leftBoarder < rightBoarder);

            return _numbers;
        }
    }
}
