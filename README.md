Задание

Разработать программу-сервис, обрабатывающую документы в формате TXT

Программе в качестве параметров передаются:
1. Путь к папке с исходными документами в фоомате TXT
2. Путь к папке с результатами

Программа следит за появлением файлов в папке с исходными документами.
Программа должна использовать 4 рабочих потока для обработки документов.
Суть обработки сводится к подсчёту количества букв в документе.
Для каждого файла из папки с исходными документами программа должна создать в папке с результатами одноимённый текстовый файл с расширением .txt, в котором должно быть записано подсчитанное число.

Исходные документы копируются в папку для обработки внешними средствами уже во время работы программы.

Программа должна завершаться только по запросу пользователя.
При этом если в момент получения события о завершении в рабочих потоках идёт обработка документов,
то надо подождать завершения обработки этиъ документов и завершить работу. Обработку оставшихся документов не начинать.