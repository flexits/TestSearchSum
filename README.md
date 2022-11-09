# TestSearchSum
Тестовое задание: ([источник](https://gist.github.com/Busyrev/cb89f309d2c32873449366023b8e0057))

> Дан ```List<uint> list``` и некое число ```ulong sum```. Ожидаемое количество элементов в ```list``` - несколько миллионов. 
> Необходимо написать метод ```FindElementsForSum```, который сможет найти наименьшие индексы ```start``` и ```end``` такие, что сумма элементов ```list``` начиная с индекса ```start``` включительно и до индекса ```end``` не включительно будет в точности равна ```sum```. Если таких ```start``` и ```end``` нельзя найти, то установить ```start``` и ```end``` равными ```0```. Решение предоставить в виде метода. Сигнаруту и название метода менять нельзя, только тело.
> 
> ```
> public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
> {
> 	// your code here
> }
> ```
> 
> Примеры:
> ```
> FindElementsForSumTest(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, out start, out end); //start будет равен 5 и end 7;
> FindElementsForSumTest(new List<uint> { 4, 5, 6, 7 }, 18, out start, out end); //start будет равен 1 и end 4;
> FindElementsForSumTest(new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, out start, out end); //start будет равен 0 и end 0;
> ```
>
> Кроме самой функции нужно придумать и написать несколько примеров (тестов) чтобы убедиться что ваша реализация работает хорошо и правильно. 
