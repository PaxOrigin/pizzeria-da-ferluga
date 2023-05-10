# pizzeria-da-ferluga
Test di fine modulo
## Considerazioni

Ho violato parecchi principi solid, con business logic associata a singole mega classi  
- Manca IOC
- Mancano funzioni di gestione file che sono state messe nel program
- Mancano operazioni di controllo sui dati inseriti, eccezioni ed errori non sono gestite
- Avrei preferito riordinare la business logic, con classi ed interfacce specifiche che si occupano di spostare i file
- Avrei aggiunto una cartella Failed Orders nella quale finiscono gli ordini il cui processing fallisce
- Avrei voluto usare il config file che ora come ora non ha alcuna utilita
- Potrebbero esserci classi non utilizzate, il codice non e' pulito o leggibile come avrei voluto.

Grazie di tutto, dei consigli e delle lezioni. Si vede che ci tieni nel formarci ed e' stato molto apprezzato, ci si vede a giugno,
Alessandro.

## Errori Trovati

Non ho messo il SaveChanges quindi quando associo all'id della ricevuta il nome del file, l'id e' sempre zero. Aggiungendo SaveChanges funziona e salva tutte le ricevute.
La classe non utilizzata order nel db crea problemi, togliere quella, la sua configurazione e il suo riferimento nel db context per far funzionare il programma

## Funzionamento

Inserire i file csv contenenti gli ordini nella cartella UnprocessedOrders (creata al primo avvio del programma nella cartella temp/FerlugaPizzeria)
Avviare nuovamente il programma

## Modifiche pomeridiane

Aggiunto in una branch separata ioc e reso il programma piu' leggibile e funzionale. 
