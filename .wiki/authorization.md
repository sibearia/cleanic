#Доступ на чтение предоставляется к ивентам: указанием типа ивента и идентификатора агрегата.

Чтобы админам не опухнуть от такой гранулярности, можно дать доступ сразу ко всем ивентам агрегата. И можно не указывать идентификатор, тогда доступ будет предоставлен к ивентам определённого типа для любого агрегата или даже ко всем ивентам всех экземпляров агрегата определённого типа. Таким образом, три основных варианта предоставления доступа:
* Доступ к агрегату по типу. Например, доступ к проектам и клиентам `[ project, client ]`.
* Доступ к экземпляру агрегата. Например, доступ к клиенту "Зоркий" и проекту "Берегиня" `[ { agg: client, id: zorki }, { agg: project, id: brgn } ]`.
* Доступ к определённым ивентам агрегата. Например, в рамках агрегата сотрудник доступ к ивенту Appeared, но отсутствие к ивенту SalaryChanged `[ { agg: employee, events: [ appeared, salary-changed ] } ]`.

При построении проекций ивенты проверяются на доступность. При отсутствии доступа в соответствующие поля не пишется ничего или пишется что-то обозначающее отсутствие доступа (на усмотрение разработчика проекции).
Поскольку строить проекции для каждого пользователя в системе дорого, строим проекции для всех возможных вариантов доступа. Что-то типа, для каждой роли свой вариант проекции.
При любых изменениях в правах, запускается перестроение проекций (добавляется ещё один вариант проекции или удаляется ненужный). Такие изменения будут не частыми и при запросе, когда проекция не успела перестроится, она достраивается во время обработки запроса.
Например, проекция "список сотрудников" может существовать в двух вариациях: полная и без поля зарплата.

#Доступ на запись предоставляется к командам: указанием типа команды и идентификатора агрегата.
Всё примерно по такой же схеме, только проще. Поскольку на основе команд ничего не строится.

Плюс надо как-то учитывать при проверках доступа отношения часть-целое между агрегатами... Или не надо. :)