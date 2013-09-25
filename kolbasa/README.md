Patterns, code review
==========
Здраствуйте!

Напоминаю, ЛР1 - это анализ чужого кода и диаграммы классов. Для работы необходимо разделится на команды (3чел) и послать список мне. Далее необходимо закачать код вашей команды и диаграмму классов на общий репозиторий. Как это делается? (Мы будем использовать систему контроля версий Git)

1. Скачать консольный Git:
<https://msysgit.googlecode.com/files/Git-1.8.3-preview20130601.exe>

2. Поставить, указать, чтобы он был в путях. Это позволит вводить команды в командной строке _far_ или _cmd_

3. Склонировать себе репозиторий. Я создал на хостинге github репозиторий у себя и пользователя вам.

    Создаем какую-либо папку , заходим в нее и там в командной строке пишем

    ``` 
    git clone http://piastu@github.com/SergeyStaroletov/Patterns13.git
    ```
    
    здесь piastu - ваш пользователь,SergeyStaroletov/Patterns13.git - репозиторий
    
    Доступ по протоколу http, чтобы не возиться с ключами, по-хорошему надо по https.

4. далее, после того, как сольется, что есть, в репозитории создаете папку (просто создаете там средствами ОС и потом добаляете)

    ```
    git add test1
    ```
    
    здесь _test1_ - ваша папка, лучше 3 фамилии. 
    Если все ок, то кладете туда ваш код и диаграмму классов

5. а потом добавляете в гит
    ```
    git add test1/*
    ```
    (надо быть на уровень выше для этого примера)

6. после добавления всех файлов необходимо сделать локальный коммит, 
    ```
    git commit -m "message"
    ```
    где _message_ - сообщение, о том, что вы сделали в коммите, будет видно в логах.

7. тк гит система распределенная, надо послать все изменения на сервер.
Наш пользователь с правами на контрибьюцию , поэтому просто пишем
    ```
    git push
    ```
    и вводим пароль __astupi13__

8. В дальнейшем изменения других можно подхватить, набрав команду

    ```git pull``` в вашей папке под системой _git_.

9. Результаты анализа кода пишете в файл с вашими фамилиями в папке чужого кода и добавляете туда аналогично.

Будут вопросы, обязательно пишите. Критерии оценки я давал. можете выбирать свои.

__Старолетов СМ__