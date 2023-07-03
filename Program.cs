/*
Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3
*/

int InputNum(string message)
{
    Console.Write(message);
    string value = Console.ReadLine();
    int result = Convert.ToInt32(value);
    return result;
}
int[] CreateArray(int size)
{
    int[] array = new int[size];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = InputNum($"Введите {i + 1} элемент");
    }
    return array;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"a[{i}] = {array[i]}");
    }
}
int CountPositiveNums(int[] array)
{
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > 0)
        {
            count++;
        }
    }
    return count;
}
int size = InputNum("Введите количество элементов > 0: ");
int[] array;
array = CreateArray(size);
PrintArray(array);
Console.WriteLine($"Количество чисел больше 0 равно {CountPositiveNums(array)}");

/*
Задача 43: Напишите программу, которая найдёт точку пересечения 
двух прямых, заданных уравнениями y = k1 * x + b1, 
y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
*/
const int cof = 0;
const int consta = 1;
const int x = 0;
const int y = 1;
const int line1 = 1;
const int line2 = 2;

double[] lineData1 = InputLineData(line1);
double[] lineData2 = InputLineData(line2);

if (ValidateLines(lineData1, lineData2))
{
    double[] coord = FindCoords(lineData1, lineData2);
    Console.Write($"Точка пересечения уравнений y={lineData1[cof]} * x + {lineData1[consta]} и y = {lineData2[cof]} * x + {lineData2[consta]}");
    Console.WriteLine($"имеет координаты ({coord[x]}, {coord[y]})");
}
double InputNum(string message)
{
    Console.WriteLine(message);
    string value = Console.ReadLine();
    int result = Convert.ToInt32(value);
    return result;
}
double[] InputLineData(int numberLine)
{
    double[] lineData = new double[2];
    lineData[cof] = InputNum($"Введите коэффициент для {numberLine} прямой >");
    lineData[consta] = InputNum($"Введите коэффициент для {numberLine} прямой >");
    return lineData;
}
double[] FindCoords(double[] lineData1, double[] lineData2)
{
    double[] coord = new double[2];
    coord[x] = (lineData1[consta] - lineData2[consta]) / (lineData2[cof] - lineData1[cof]);
    coord[y] = lineData1[consta] * coord[x] + lineData1[consta];
    return coord;
}
bool ValidateLines(double[] lineData1, double[] lineData2)
{
    if (lineData1[cof] == lineData2[cof])
    {
        if (lineData1[consta] == lineData2[consta])
        {
            Console.WriteLine("Прямые совпадают");
            return false;
        }
        else
        {
            Console.WriteLine("Прямые параллельны");
            return false;
        }
    }
    return true;
}