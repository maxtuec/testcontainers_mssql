1. Fu r welches Datenmodell haben Sie sich entschieden? ER-Diagramm, etwaige Besonderheiten erklären.
2. Dokumentieren Sie auf Request-Ebene den gesamten Workflow anhand eines mo glichst
durchga ngigen Beispiels (vom Einpflegen der Haltestellen und Feiertage bis zur Planung
und Durchfu hrung einer Fahrt). Sie ko nnen ein Tool Ihrer Wahl einsetzen, z. B. Postman
Workflows, VS Code, etc. HTTP-Requests inkl. HTTP-Verb, URL, Parametern, Body und Headern
3. Wie stellen Sie sicher, dass das Einchecken der Busse nur mit einem gu ltigen API-Key mo glich ist?
4. Ein Angreifer hat Zugriff auf ein Datenbank-Backup Ihres Produktivsystems bekommen.
Welchen Schaden kann er anrichten?
5. Bei welchen Teilen Ihres Systems ist eine korrekte Funktionsweise aus Ihrer Sicht am kritischsten? Welche Maßnahmen haben Sie getroffen, um sie zu gewa hrleisten?
6. Wie haben Sie die Berechnung passender Routen bei Fahrplanabfragen modular umgesetzt? Welche Teile Ihres Codes mu ssen Sie a ndern, um eine andere Variante einzusetzen?
7. Welche Pru fungen fu hren Sie bei einem Check-in (der Standortdaten eines Busses) durch,
um die Korrektheit der Daten zu gewa hrleisten?
8. Wie stellen Sie sicher, dass Ihre API auch in außergewo hnlichen Konstellationen (Jahreswechsel, Zeitumstellung, Feiertag in den Schulferien, etc.) stets korrekte Fahrplandaten
liefert?
9. Bei der Ü bertragung eines API-Keys auf einen Bus ist etwas schiefgelaufen, der Bus liefert
mangels gu ltiger Authentifizierung keine Check-in-Daten mehr. Ü berlegen Sie, wie Sie a)
dieses Problem im Betrieb mo glichst rasch erkennen ko nnen und b) Auskunft geben ko nnen, seit wann das Problem besteht.
10. Denken Sie an die Skalierbarkeit Ihres Projekts: Die Wiener Linien mo chten Ihr Produkt
mit u ber 1.000 Fahrzeugen nutzen. Was macht Ihnen am meisten Kopfzerbrechen?
11. Wenn Sie das Projekt neu anfangen wu rden – was wu rden Sie anders machen?


TODO:

 ? wegen geography als coordinates oder decimal
 ? wegen DRIVE/TRIP/JOURNEY/TOUR/RIDE