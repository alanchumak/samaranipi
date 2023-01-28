Создать веб-приложение по управлению договорами используя ASP .NET Core (желательно версию 5.00), 
EntityFrameworkCore и любую библиотеку для взаимодействия с Excel.

Необходимо сделать:
- [модель данных] - создать модель данных;
- [база данных] - на основе модели данных создать базу данных (БД на ваш выбор);

- [статичная страница] - форма с выбором файла (Excel) для импорта данных;
- [API] - метод для чтения и загрузки данных из файла (Excel) в БД;

- [статичная страница] - таблица с договорами и этапами (данные договоров загружаются через JavaScript, можно использовать чистый JS или любой современный фреймворк по созданию UI, например React);
- [API] - получение списка договоров в формате json;
- [API] - получение списка этапов договора по выбранному договору в формате json;


Модель:

ДОГОВОР
- ШИФР ДОГОВОРА
- НАИМЕНОВАНИЕ ДОГОВОРА
- ЗАКАЗЧИК


ЭТАП ДОГОВОРА
- НАИМЕНОВАНИЕ ЭТАПА
- ДАТА НАЧАЛА
- ДАТА ОКОНЧАНИЯ

Контроллеры:
/Contracts
	/Index  [статичная страница]
	/Import [статичная страница]
/api/Import
	/UploadFile [загрузка файла, чтение из файла, добавление данных БД]
/api/Contracts
	/GetContracts [список договоров в json]
	/GetContractStages [список этапов договора в json]

---------------------------------------------------------
Для запуска, из папки проекта выполнить:

### `dotnet run`

Пример входного .xlsx:

### input.xlsx