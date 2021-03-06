Построить веб-приложение, поддерживающую заданную функциональность:
1.	На основе сущностей предметной области создать классы их описывающие, соблюдая принципы SOLID. (DI по желанию).
2.	Классы и методы должны иметь отражающую их функциональность названия и должны быть грамотно структурированы в приложении (folders, namespaces).
3.	Оформление кода должно соответствовать C# Code Conventions.
4.	Информацию о предметной области хранить в БД, для доступа использовать Entity Framework. В качестве СУБД использовать MS SQL (не Compact).
5.	Архитектура приложения должна соответствовать шаблону MVC.
6.	Выполнить журналирование событий, то есть информацию о возникающих исключениях и событиях в системе обрабатывать средствами среды.
7.	Код должен содержать комментарии (все классы верхнего уровня, нетривиальные методы и конструкторы).
8.	Уровень доступа к данным должен быть вынесен в отдельный проект.
9.	Реализовать разграничение прав доступа пользователей системы к компонентам приложения (минимум 3 роли).
10.	Все поля ввода должны быть с валидацией данных.


Дополнительно, к требованиям изложенным выше, более чем желательно обеспечить выполнение следующих требований.
1.	покрытие юнит-тестами бизнес-логики.
2.	Использовать журналирование событий.
3.	Обработка исключений.
4.	Самостоятельное расширение постановки задачи по функциональности приветствуется.

Библиотека
Читатель регистрируется в системе и далее имеет возможность осуществлять поиск (по автору/названию) и заказ Книг в Каталоге. Незарегистрированный Читатель не может заказать книгу. Для каталога реализовать возможность сортировки книг:

по названию;
по автору;
по изданию;
по дате издания.
Библиотекарь выдает читателю книгу на абонемент или в читальный зал. Книга выдается Читателю на определенный срок. При не возврате книги в срок, читателю начисляется штраф.

Книга может присутствовать в библиотеке в одном или нескольких экземплярах. Система ведет учет доступного количества книг.

Каждый пользователь имеет личный кабинет, в котором отображается регистрационная информация, а также

для читателя:

список книг, которые находятся на абонементе и дата предполагаемого возвращения (если дата просрочена, отображается размер штрафа);
для библиотекаря:

список заказов читателей.
Администратор системы владеет правами:

добавления/удаления книги, редактирования информации о книге;
создания/удаления библиотекаря;
блокирования/разблокирования пользователя.

